#!/bin/sh
#if bin_sh
  # Doing this because arguments can't be used with /usr/bin/env on linux, just mac
  exec fsharpi --define:mono_posix --exec $0 $*
#endif

#if mono_posix
#r "Mono.Posix.dll"
open Mono.Unix.Native
let applyExecutionPermissionUnix path =
    let _,stat = Syscall.lstat(path)
    Syscall.chmod(path, FilePermissions.S_IXUSR ||| stat.st_mode) |> ignore
#else
let applyExecutionPermissionUnix _ = ()
#endif

open System
open System.IO
open System.Diagnostics
open System.IO

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__

let createDir d= Directory.CreateDirectory(d) |> ignore

let paketPath = Path.Combine("bin", "paket.exe")
if not (File.Exists paketPath) then
    let url = "http://fsprojects.github.io/Paket/stable"
    use wc = new Net.WebClient()
    let tmp = Path.GetTempFileName()
    let stable = wc.DownloadString(url)
    wc.DownloadFile(stable, tmp)
    createDir "bin"
    File.Move(tmp, paketPath)
let exec (exePath:string) (args:string seq) =
    let processStart (psi:ProcessStartInfo) =
        let ps = Process.Start(psi)
        ps.WaitForExit ()
        ps.ExitCode
    applyExecutionPermissionUnix exePath
    let exitCode = ProcessStartInfo(
                        exePath,
                        args |> String.concat " ",
                        UseShellExecute = false) 
                   |> processStart
    if exitCode <> 0 then
        exit exitCode
    ()

exec paketPath ["install"]

#I "packages/FSharp.Compiler.Service/lib/net45/"
#r "FSharp.Compiler.Service.dll"
#I "packages/FSharp.Formatting/lib/net40/"
#r "RazorEngine.dll"
#r "FSharp.MetadataFormat.dll"
#r "FSharp.Literate.dll"
#r "FSharp.CodeFormat.dll"

open FSharp.MetadataFormat
open FSharp.Literate

let root = Path.Combine(__SOURCE_DIRECTORY__, "..")

let outputDir = Path.Combine(root, "docs")
createDir outputDir

let docContent = "doc-content"
let docStyles = Path.Combine(docContent, "styles")
let baseOutput = Path.Combine(outputDir, "styles")
createDir docStyles
for dir in Directory.GetDirectories(docStyles) do
    let outputContentDir = Path.Combine(baseOutput, Path.GetFileName(dir))
    createDir outputContentDir
    for file in Directory.GetFiles(dir) do
      File.Copy(file, Path.Combine(outputContentDir, Path.GetFileName(file)), overwrite = true)
for file in Directory.GetFiles(docStyles) do
    File.Copy(file, Path.Combine(baseOutput, Path.GetFileName(file)), overwrite = true)

let dll = Path.Combine(root, 
                        "src",
                        "FSharp.Interop.NullOptAble",
                        "bin",
                        "Debug",
                        "netstandard1.6", 
                        "FSharp.Interop.NullOptAble.dll")

let options = "--reference:\"" + dll + "\""

let template = "docpage.cshtml"
let templateDirs = [ Path.Combine(docContent, "templates");
        Path.Combine(docContent, "templates", "reference") ]

let projInfo =
    [ "project-author",  ["authors"] |> String.concat ", "
      "project-summary", "description"
      "project-github",  "gitHubProjectUrl"
      "project-nuget", "nugetUrl"
      "project-name", "projectName"
      "root" , "projectUrl" ]

Literate.ProcessMarkdown(
      Path.Combine(root,"README.md"),
      output = Path.Combine(outputDir, "index.html"),
      compilerOptions = options,
      includeSource = true )
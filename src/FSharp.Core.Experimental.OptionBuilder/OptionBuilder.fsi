module FSharp.Core.Experimental.OptionBuilder
  type OptionBuilder =
    class
      new : unit -> OptionBuilder
      member Bind : m:'T option * f:('T -> 'i option) -> 'i option
      member
        Bind : m:System.Nullable<'T> * f:('T -> 'h option) -> 'h option
                 when 'T : (new : unit -> 'T) and 'T : struct and
                      'T :> System.ValueType
      member Bind : m:'T * f:('T -> 'g option) -> 'g option when 'T : null
      member Delay : f:(unit -> 'f) -> (unit -> 'f)
      member Return : x:'T -> 'T option
      member ReturnFrom : m:'T option -> 'T option
      member
        ReturnFrom : m:System.Nullable<'T> -> 'T option
                       when 'T : (new : unit -> 'T) and 'T : struct and
                            'T :> System.ValueType
      member ReturnFrom : m:'T -> 'T option when 'T : null
      member Run : f:(unit -> 'e) -> 'e
      member
        TryFinally : delayedExpr:(unit -> 'c) * compensation:(unit -> unit) ->
                       'c
      member TryWith : delayedExpr:(unit -> 'd) * handler:(exn -> 'd) -> 'd
      member
        Using : resource:'a * body:('a -> 'b) -> 'b
                  when 'a :> System.IDisposable and 'a : null
      member Zero : unit -> 'j option
    end
  val option : OptionBuilder
  type ChooseSeqBuilder =
    class
      new : unit -> ChooseSeqBuilder
      member Bind : m:'T option * f:('T -> 'm option) -> 'm option
      member
        Bind : m:System.Nullable<'T> * f:('T -> 'l option) -> 'l option
                 when 'T : (new : unit -> 'T) and 'T : struct and
                      'T :> System.ValueType
      member Bind : m:'T * f:('T -> 'k option) -> 'k option when 'T : null
      member Combine : a:seq<'j> * b:seq<'j> -> seq<'j>
      member Delay : f:(unit -> seq<'i>) -> seq<'i>
      member For : sequence:seq<'a> * body:('a -> seq<'b>) -> seq<'b>
      member private ForceRun : f:seq<'T> -> seq<'T>
      member Run : f:seq<'h> -> seq<'h>
      member
        TryFinally : delayedExpr:seq<'e> * compensation:(unit -> unit) ->
                       seq<'e>
      member
        TryWith : delayedExpr:seq<'f> * handler:(exn -> seq<'f>) -> seq<'f>
      member
        Using : resource:'c * body:('c -> seq<'d>) -> seq<'d>
                  when 'c :> System.IDisposable and 'c : null
      member While : guard:(unit -> bool) * delayedExpr:seq<'g> -> seq<'g>
      member Yield : x:'T -> seq<'T>
      member YieldFrom : m:'T option -> seq<'T>
      member
        YieldFrom : m:System.Nullable<'T> -> seq<'T>
                      when 'T : (new : unit -> 'T) and 'T : struct and
                           'T :> System.ValueType
      member YieldFrom : m:'T -> seq<'T> when 'T : null
      member YieldFrom : m:seq<'T> -> seq<'T>
      member YieldFrom : m:string -> seq<string>
      member Zero : unit -> seq<'n>
    end
  val chooseSeq : ChooseSeqBuilder



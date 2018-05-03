namespace FSharp.Interop.NullOptAble

///Extended functions added to Option
module Option =

    ///**Description**
    ///
    ///Convert a tuple result of a try method to an option type.
    ///
    ///**Parameters**
    ///
    ///  * `value` - parameter of type `bool * 'a`
    [<CompiledName("OfTryTuple")>]
    val ofTryTuple : value:(bool * 'a) -> 'a option
    
  
    ///**Description**
    ///
    ///ofObj only when predicate returns true
    ///
    ///**Parameters**
    ///
    ///  * `predicate` - parameter of type `'a -> bool`
    ///  * `value` - parameter of type `'a`
    ///
    ///**Output Type**
    ///  * `'a option`
    ///
    [<CompiledName("OfObjWhen")>]
    val ofObjWhen : predicate:('a -> bool) -> value:'a -> 'a option 
            when 'a:null
    
  
   
 
    ///**Description**
    ///
    ///ofObj only when predicate returns false
    ///
    ///**Parameters**
    ///
    ///  * `predicate` - parameter of type `'a -> bool`
    ///  * `value` - parameter of type `'a`
    ///
    ///**Output Type**
    ///  * `'a option`
    ///
    [<CompiledName("OfObjWhenNot")>]
    val ofObjWhenNot : predicate:('a -> bool) -> value:'a -> 'a option 
            when 'a:null


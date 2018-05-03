namespace FSharp.Interop.NullOptAble
module Option =
    ///**Description**
    ///
    ///Convert a tuple result of a try method to an option type.
    ///
    ///**Parameters**
    ///
    ///  * `tryTuple` - parameter of type `bool * 'a`
    ///
    val ofTryTuple : tryTuple:(bool * 'a) -> 'a option
    
    ///**Description**
    ///
    ///Convert a string to an option type using a passed in predicate.
    ///
    ///**Parameters**
    ///
    ///  * `predicate` - parameter of type `string -> bool`
    ///  * `str` - parameter of type `string`
    ///
    ///**Output Type**
    ///
    ///  * `string option`
    ///
    val ofStringWhen : predicate:(string -> bool) -> str:string -> string option
    
    ///**Description**
    ///
    ///Convert a string to an option type using then contrary of a passed in predicate.
    ///
    ///**Parameters**
    ///
    ///  * `predicate` - parameter of type `string -> bool`
    ///  * `str` - parameter of type `string`
    ///
    ///**Output Type**
    ///
    ///  * `string option`
    val ofStringWhenNot : predicate:(string -> bool) -> str:string-> string option


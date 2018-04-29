namespace FSharp.Interop.NullOptAble
  ///**Description**
  ///
  ///Optional Operators that you can use for defaults, bindings and mapping.
  ///See [examples](https://ekonbenefits.github.io/FSharp.Interop.NullOptAble/RealWorldOperators.html) for usage.
  ///
  module Operators = begin

    ///**Description**
    ///
    ///Overloaded defaultWith operator
    ///
    ///**Parameters**
    ///
    ///  * `a` - parameter of type ` 'a option or 'a Nullable or 'a : null `
    ///  * `b` - parameter of type ` 'a Lazy`
    ///
    ///**Output Type**
    ///
    ///  * ` 'a`
    ///
    val inline ( |?-> ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member DefaultWith : ^a * ^b -> ^c)

    ///**Description**
    ///
    /// Overloaded map operator pointing right
    ///
    ///**Parameters**
    ///
    ///  * `a` - parameter of type ` 'a option or 'a Nullable or 'a : null `
    ///  * `b` - parameter of type ` 'a -> 'b`
    ///
    ///**Output Type**
    ///
    ///  * ` 'b option`
    ///
    val inline ( |>?@ ) : a: ^a -> b: ^b ->  ^c
        when (NullOptAble or  ^a) : (static member Map : ^a * ^b -> ^c)

    ///**Description**
    ///
    /// Overloaded map operator pointing left
    ///
    ///**Parameters**
    ///
    ///  * `b` - parameter of type ` 'a -> 'b`
    ///  * `a` - parameter of type ` 'a option or 'a Nullable or 'a : null `
    ///
    ///**Output Type**
    ///
    ///  * ` 'b option`
    val inline ( @?<| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Map : ^b * ^a -> ^c)
 
    ///**Description**
    ///
    /// Overloaded map2 operator pointing right
    ///
    ///**Parameters**
    ///
    ///  * `a` - tuple2 of type ` 'a option or 'a Nullable or 'a : null `
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c`
    ///
    ///**Output Type**
    ///
    ///  * ` 'c option`
    val inline ( ||>?@ ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Map2 : ^a * ^b -> ^c)

    ///**Description**
    ///
    /// Overloaded map2 operator pointing left
    ///
    ///**Parameters**
    ///
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c`
    ///  * `a` - tuple2 of type ` 'a option or 'a Nullable or 'a : null `
    ///
    ///**Output Type**
    ///
    ///  * ` 'c option`
    val inline ( @?<|| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Map2 : ^b * ^a -> ^c)
    
    ///**Description**
    ///
    /// Overloaded map3 operator pointing right
    ///
    ///**Parameters**
    ///
    ///  * `a` - tuple3 of type ` 'a option or 'a Nullable or 'a : null `
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c ->'d`
    ///
    ///**Output Type**
    ///
    ///  * ` 'd option`
    val inline ( |||>?@ ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Map3 : ^a * ^b -> ^c)
    ///**Description**
    ///
    /// Overloaded map3 operator pointing left
    ///
    ///**Parameters**
    ///
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c ->'d`
    ///  * `a` - tuple3 of type ` 'a option or 'a Nullable or 'a : null `
    ///
    ///**Output Type**
    ///
    ///  * ` 'd option`
    val inline ( @?<||| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Map3 : ^b * ^a -> ^c)
    
    ///**Description**
    ///
    /// Overloaded bind operator pointing right
    ///
    ///**Parameters**
    ///
    ///  * `a` - parameter of type ` 'a option or 'a Nullable or 'a : null `
    ///  * `b` - parameter of type ` 'a -> 'b option or 'b Nullable or 'b:null`
    ///**Output Type**
    ///  * ` 'b option`
    val inline ( |>? ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Bind : ^a * ^b -> ^c)
    
    ///**Description**
    ///
    /// Overloaded bind operator pointing left
    ///
    ///**Parameters**
    ///
    ///  * `b` - parameter of type ` 'a -> 'b option or 'b Nullable or 'b:null`
    ///  * `a` - parameter of type ` 'a option or 'a Nullable or 'a : null `
    ///
    ///**Output Type**
    ///
    ///  * ` 'b option`
    val inline ( ?<| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Bind : ^b * ^a -> ^c)
    
    ///**Description**
    ///
    /// Overloaded bind2 operator pointing right
    ///
    ///**Parameters**
    ///
    ///  * `a` - tuple2 of type ` 'a option or 'a Nullable or 'a : null `
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c option or 'c Nullable or 'c:null`
    ///
    ///**Output Type**
    ///
    ///  * ` 'c option`
    val inline ( ||>? ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Bind2 : ^a * ^b -> ^c)
    
    ///**Description**
    ///
    /// Overloaded bind2 operator pointing left
    ///
    ///**Parameters**
    ///
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c option or 'c Nullable or 'c:null`
    ///  * `a` - tuple2 of type ` 'a option or 'a Nullable or 'a : null `
    ///
    ///**Output Type**
    ///
    ///  * ` 'c option`
    val inline ( ?<|| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Bind2 : ^b * ^a -> ^c)
    
    ///**Description**
    ///
    /// Overloaded bind3 operator pointing right
    ///
    ///**Parameters**
    ///
    ///  * `a` - tuple3 of type ` 'a option or 'a Nullable or 'a : null `
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c -> 'd option or 'd Nullable or 'd:null`
    ///
    ///**Output Type**
    ///
    ///  * ` 'd option`
    val inline ( |||>? ) : a: ^a -> b: ^b -> ^c
        when (NullOptAble or  ^a) : (static member Bind3 : ^a * ^b -> ^c)
    
    ///**Description**
    ///
    /// Overloaded bind3 operator pointing right
    ///
    ///**Parameters**
    ///
    ///  * `b` - parameter of type ` 'a -> 'b -> 'c -> 'd option or 'd Nullable or 'd:null`
    ///  * `a` - tuple3 of type ` 'a option or 'a Nullable or 'a : null `
    ///
    ///**Output Type**
    ///
    ///  * ` 'd option`
    val inline ( ?<||| ) : b: ^a -> a: ^b -> ^c
        when (NullOptAble or  ^b) : (static member Bind3 : ^b * ^a -> ^c)
  end
//10. Swap 2 variables without using a Temp Location?
//    Shorter Version in F#
let swap(a:int, b:int) = b,a

printfn($"a=5, b=3")
let x,y = swap(5,3)
printfn($"a={x}, b={y}")

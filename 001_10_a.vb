'10. Swap 2 variables without using a Temp Location?
Module Swapper
    Sub Swap(a As Int64, b As Int64)
        'a=5, b=3
        Console.WriteLine($"a={a}, b={b}")
        a = a - b 'a=5-3=2
        b = a + b 'b=2+3=5
        a = b - a 'a=5-2=3
        'a=3, b=5
        Console.WriteLine($"a={a}, b={b}")
    End Sub
    Sub Main()
        Swap(5, 3)
        Console.ReadKey() 'to see the output till key is pressed
    End Sub

End Module

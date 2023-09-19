namespace CSharpNotes.Types;

public class DeclaringLocalVariables
{
    [Fact]
    public void ExplicitlyTypedLocalVariable()
    {
        int a = 0;
        int b = 2;

        string dogName = "Rover";

        Assert.Equal("Rover", dogName);

        Assert.Equal(0, a);
        Assert.Equal(2, b);
    }

    [Fact]
    public void ImplicitlyTypedLocalVariablesWithVar()
    {
        var a = 0;
        var b = 1.0; //defaults to a double
        var c = "Cat";
        var d = 'A';
        var e = true;
        decimal salary = 80123.23M; //specifically a type with exactly 2 decimal places -- declare by putting "M" after the number
        float floatingPoint = 12345.1244F; //defining floating point instead of double requires "F" after the number

        var rover = new Dog(); //Dog class defined at bottom of this file
    }

    [Fact]
    public void ImplicitlyTypedLocalVariablesWithNew()
    {
        // .NET 5
        Dog rover = new();
    }
}

public class Dog { }

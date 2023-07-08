# CharMatrix

`CharMatrix` is a lightweight .NET library for generating character matrices from bitmaps. This is primarily a hobby project, but releases will be published to NuGet for use by others.

## Usage

This library is composed of many similarly structured generator class which are constructed with a bitmap accessor. The interface for the bitmap accessor is provided as part of this library (see `IBitmapAccessor`) and is left as an interface so that consumers can adapt to it in their own way. Below is a very basic implementation of a bitmap accessor backed by a boolean array (this is similar to the accessor used in the tests for the library):

```csharp
public class BooleanArrayAccessor : IBitmapAccessor
{
    private readonly bool[,] _array;

    public BooleanArrayAccessor(bool[,] array)
    {
        _array = array ?? throw new ArgumentNullException(nameof(array));
    }

    public bool this[int row, int column] => _array[row, column];

    public int Rows => _array.GetLength(0);

    public int Columns => _array.GetLength(1);
}
```

A generator class (such as `HalfBlockMatrixGenerator`) simply needs an implementer of the aforementioned interface during construction, after which it can generate it's character matrix, like so:

```csharp
var accessor = new BooleanArrayAccessor(new[,] {...});
var generator = new HalfBlockMatrixGenerator(accessor);

string matrix = generator.Generate(); 
```

## Examples

Below are a list of all character matrix generators provided by this library with an example of their output.

### `HalfBlockMatrixGenerator`
```text
 ▄▀▀▀▀▄ 
█ █ █  █
█ ▄▄▄▀ █
 ▀▄▄▄▄▀ 
```
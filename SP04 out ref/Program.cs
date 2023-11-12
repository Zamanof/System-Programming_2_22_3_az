// ref, out
int a;
//Console.WriteLine(a);
Foo(out a);
Console.WriteLine(a);
Foo(out int u);
Console.WriteLine(u);
void Foo(out int a)
{
    a = 56;
}
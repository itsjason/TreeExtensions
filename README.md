TreeExtensions
==============

Generic Tree interface and extension methods for .NET 4
-------------------------------------------------------

Have you always wanted to operate on your object heirarchies 
(non-binary tree structures) but never found a good implementation?
Well, look no further, my friend. ITree<T> is all you need!

All you need to do to implement the interface is include:

`public T[] Children { get; set; }`

You'll receive such prizes as:

* `var onlyTheBest = tree.Filter(x => x.Awesome == MOST_DEF);`
* `var pancake = tree.Flatten();`
* `tree.Apply(x => x.SetVolume(11));`

Probably you'll want to install this bad boy using [NuGet](http://nuget.org/packages/TreeExtensions)

Here's the command for the ultra-lazy:

`Install-Package TreeExtensions`

Thanks!

Jason

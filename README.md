# GildedRose-Refactoring-Kata
Let's try to do refactoring for GildedRose-Refactoring-Kata in c#

1-to copy of c# file from GildedRose-Refactoring-Kata repository.
2- Push the original code in c# in the new repository.
3- Create new branch called  refactGildedRose to work on it.
4- Based on GildedRose Requirements Specification file : we create unit tests which test all cases. All tests passed ( green) with actual code. This step in very important to start refactoring after any change of code we will re run all tests and  they shoud all passed.
5- Start refactoring of GildedRose class : add foreach to replace for and loop in element not with index : avoid using index when we call item.
6- Cleanup if conditions : remove redudant condition and merge child if (without else ) with parent if.

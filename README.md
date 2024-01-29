# GildedRose-Refactoring-Kata
Let's try to do refactoring for GildedRose-Refactoring-Kata in c#

1-to copy of c# file from GildedRose-Refactoring-Kata repository.
2- Push the original code in c# in the new repository.
3- Create new branch called  refactGildedRose to work on it.
4- Based on GildedRose Requirements Specification file : we create unit tests which test all cases. All tests passed ( green) with actual code. This step in very important to start refactoring after any change of code we will re run all tests and  they shoud all passed.
5- Start refactoring of GildedRose class : add foreach to replace for and loop in element not with index : avoid using index when we call item.
6- Cleanup if conditions : remove redudant condition and merge child if (without else ) with parent if.
7- Start to change the logic of if conditions to be by item names and be sure that all tests still passed :
    - create boolean variables to make conditions more readable.
    - change first if condition put it by item not in (sulfuras, agedbrie, sulfuras) which decrease quantity when    	quality >0.
    - Second else block : it was else if not agedBrie and not backstage chenged by two if  for aged Brie, 	backstage the old behavior increase quality by 1 and check if backstage continue to increase.
    - third (if block) one check if it is not sulfuras so I changed to check quality updating method linked the 	rest of items.
    - last (if block) try to put item name logic in if condition and keep the check in sellin value for now
8- put conditon linked to sell in (<0) under conditons by item name.
9- group the treatments linked to each item under the item name condition.

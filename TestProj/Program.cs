// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using static Algorithm.Chapter2.Solution;
using static Algorithm.Chapter3.Solution;
using static Algorithm.Chapter4.Solution;
using static Algorithm.Chapter5.Solution;
using static Algorithm.Chapter6.Solution;
using static Algorithm.Utility.Utilities;

// ====================================================================================
// ReplaceSpaceP53
// ReplaceSpaceP53(new List<char> { 'a', ' ', 'b' });
// ReplaceSpaceP53(new List<char> { ' ', ' ', ' ' });

// ReversePrintLinkedListP58
// var linkedListP58 = new LinkedList<string>(new[]
// {
//     "1","2","3","4","5","6"
// });
// ReversePrintLinkedListStackP58(linkedListP58);
// ReversePrintLinkedListRecursiveP58(linkedListP58);

// ====================================================================================
// RebuildBinaryTreeP62
// var preOrder = new[] { 1, 2, 4, 7, 3, 5, 6, 8 };
// var inOrder = new[] { 4, 7, 2, 1, 5, 3, 8, 6 };
// var root = RebuildBinaryTreeP62(preOrder, inOrder);
// Print2D(root);

// ====================================================================================
// NextNodeInOrderP64
// Test1_7();
// Test8_11();
// Test12_15();
// Test16();

// ====================================================================================
// OneQueueFromTwoStacksP68
// var queue = new CustomQueue<char>();

// queue.Enqueue('a');
// queue.Enqueue('b');
// queue.Enqueue('c');

// char head = queue.Dequeue();
// Test(head, 'a');

// head = queue.Dequeue();
// Test(head, 'b');

// queue.Enqueue('d');
// head = queue.Dequeue();
// Test(head, 'c');

// queue.Enqueue('e');
// head = queue.Dequeue();
// Test(head, 'd');

// head = queue.Dequeue();
// Test(head, 'e');

// ====================================================================================
// FibonacciRecursiveP78
// Console.WriteLine(FibonacciLoopP78(40));
// Console.WriteLine(FibonacciRecursiveP78(40));

// Console.WriteLine(FibonacciLoopP78(50));
// // Console.WriteLine(FibonacciRecursiveP78(50)); // don't do it, too slow

// ====================================================================================
// QuickSortP80
// var input1 = new[] { 3, 2 };
// var input2 = new[] { 12, 22, 88, 44, 23, 865, 45, 231, 578, 45, 84252, 658, 0, 1, 987, 34, 654, 2342, 33 };
// var input3 = new[] { 3, 2, 5, 3, 6, 8, 1, 0, 4, 5 };
// QuickSortP80(input1);
// QuickSortP80(input2);
// QuickSortP80(input3);
// Console.Read();

// ====================================================================================
// RotationArrayMinP84
// Console.WriteLine(RotationArrayMinP84(new[] { 3, 4, 5, -2, 1, 2, 2 }));
// Console.WriteLine(RotationArrayMinP84(new[] { 22, 33, 56, 13, 15 }));
// 典型输入，单调升序的数组的一个旋转
// var array1 = new[] { 3, 4, 5, 1, 2 };
// TestRotatedArrayMinP84(array1, 1);

// // 有重复数字，并且重复的数字刚好的最小的数字
// var array2 = new[] { 3, 4, 5, 1, 1, 2 };
// TestRotatedArrayMinP84(array2, 1);

// // 有重复数字，但重复的数字不是第一个数字和最后一个数字
// var array3 = new[] { 3, 4, 5, 1, 2, 2 };
// TestRotatedArrayMinP84(array3, 1);

// // 有重复的数字，并且重复的数字刚好是第一个数字和最后一个数字
// var array4 = new[] { 1, 0, 1, 1, 1 };
// TestRotatedArrayMinP84(array4, 0);

// // 单调升序数组，旋转0个元素，也就是单调升序数组本身
// var array5 = new[] { 1, 2, 3, 4, 5 };
// TestRotatedArrayMinP84(array5, 1);

// // 数组中只有一个数字
// var array6 = new[] { 2 };
// TestRotatedArrayMinP84(array6, 2);

// // 输入nullptr
// TestRotatedArrayMinP84(null, 0);

// ====================================================================================
// HasPathP90
// TestHasPathP90();

// ====================================================================================
// MaxProductAfterCutP97
// TestMaxProductAfterCutP97DynPlan();

// ====================================================================================
// P100AlphaDecimal
// P100AlphaDecimalTest();

// ====================================================================================
// P100CountOneShiftOne
// TestP100CountOne();

// ====================================================================================
// P110Power
// P110PowerTest("P110PowerTest1", 2, 3, 8, false);

// // 底数为负数、指数为正数
// P110PowerTest("P110PowerTest2", -2, 3, -8, false);

// // 指数为负数
// P110PowerTest("P110PowerTest3", 2, -3, 0.125m, false);

// // 指数为0
// P110PowerTest("P110PowerTest4", 2, 0, 1, false);

// // 底数、指数都为0
// P110PowerTest("P110PowerTest5", 0, 0, 1, false);

// // 底数为0、指数为正数
// P110PowerTest("P110PowerTest6", 0, 4, 0, false);

// // 底数为0、指数为负数
// P110PowerTest("P110PowerTest7", 0, -4, 0, true);

// ====================================================================================
// P116PrintNumberByDecimalCount
// TestP116PrintNumberByDecimalCount();

// ====================================================================================
// P120DelLinkedListNode
// No test

// ====================================================================================
// P126Regex
// P126RegexTest("Test01", "", "", true);
// P126RegexTest("Test02", "", ".*", true);
// P126RegexTest("Test03", "", ".", false);
// P126RegexTest("Test04", "", "c*", true);
// P126RegexTest("Test05", "a", ".*", true);
// P126RegexTest("Test06", "a", "a.", false);
// P126RegexTest("Test07", "a", "", false);
// P126RegexTest("Test08", "a", ".", true);
// P126RegexTest("Test09", "a", "ab*", true);
// P126RegexTest("Test10", "a", "ab*a", false);
// P126RegexTest("Test11", "aa", "aa", true);
// P126RegexTest("Test12", "aa", "a*", true);
// P126RegexTest("Test13", "aa", ".*", true);
// P126RegexTest("Test14", "aa", ".", false);
// P126RegexTest("Test15", "ab", ".*", true);
// P126RegexTest("Test16", "ab", ".*", true);
// P126RegexTest("Test17", "aaa", "aa*", true);
// P126RegexTest("Test18", "aaa", "aa.a", false);
// P126RegexTest("Test19", "aaa", "a.a", true);
// P126RegexTest("Test20", "aaa", ".a", false);
// P126RegexTest("Test21", "aaa", "a*a", true);
// P126RegexTest("Test22", "aaa", "ab*a", false);
// P126RegexTest("Test23", "aaa", "ab*ac*a", true);
// P126RegexTest("Test24", "aaa", "ab*a*c*a", true);
// P126RegexTest("Test25", "aaa", ".*", true);
// P126RegexTest("Test26", "aab", "c*a*b", true);
// P126RegexTest("Test27", "aaca", "ab*a*c*a", true);
// P126RegexTest("Test28", "aaba", "ab*a*c*a", false);
// P126RegexTest("Test29", "bbbba", ".*a*a", true);
// P126RegexTest("Test30", "bcbbabab", ".*a*a", false);

// ====================================================================================
// P127MatchNumber
// P127Test("Test1", "100", true);
// P127Test("Test2", "123.45e+6", true);
// P127Test("Test3", "+500", true);
// P127Test("Test4", "5e2", true);
// P127Test("Test5", "3.1416", true);
// P127Test("Test6", "600.", true);
// P127Test("Test7", "-.123", true);
// P127Test("Test8", "-1E-16", true);
// P127Test("Test9", "1.79769313486232E+308", true);
// P127Test("Test10", "12e", false);
// P127Test("Test11", "1a3.14", false);
// P127Test("Test12", "1+23", false);
// P127Test("Test13", "1.2.3", false);
// P127Test("Test14", "+-5", false);
// P127Test("Test15", "12e+5.4", false);
// P127Test("Test16", ".", false);
// P127Test("Test17", ".e1", false);
// P127Test("Test18", "e1", false);
// P127Test("Test19", "+.", false);
// P127Test("Test20", "", false);
// P127Test("Test21", null, false);

// ====================================================================================
// P130MoveArrayOddEven
// var p130TstArry = new[] { 1, 7, 3, 8, 2, 8, 0, 3, 2, 5, 7, 9, 3, 1, 6, 8, 0, 3, 1, 6, 7, 2 };
// P130MoveArrayOddEvenTwoPointers(p130TstArry);
// Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(p130TstArry));

// ====================================================================================
// P140EntryOfLoopNodes
// P140Test1();
// P140Test2();
// P140Test3();
// P140Test4();
// P140Test5();
// P140Test6();
// P140Test7();

// ====================================================================================
// P145ReverseLinkedList
// P145Test1();
// P145Test2();
// P145Test3();

// ====================================================================================
// P147MergeSortedLinkedList
// P147Test1();
// P147Test2();
// P147Test3();
// P147Test4();
// P147Test5();

// ====================================================================================
// P151HasSubTree
// P151Test1();
// P151Test2();
// P151Test3();
// P151Test4();
// P151Test5();
// P151Test6();
// P151Test7();
// P151Test8();
// P151Test9();

// ====================================================================================
// P156GetMirrorTree
// P156Test1();
// P156Test2();
// P156Test3();
// P156Test4();
// P156Test5();

// ====================================================================================
// P160IsTreeSymmetric
// P160Test1();
// P160Test2();
// P160Test3();
// P160Test4();
// P160Test5();
// P160Test6();
// P160Test7();
// P160Test8();
// P160Test9();
// P160Test10(); 

// ====================================================================================
// P163PrintMatrixSpiralCore
// /*
// 1    
// */
// P163Test(1, 1);

// /*
// 1    2
// 3    4
// */
// P163Test(2, 2);

// /*
// 1    2    3    4
// 5    6    7    8
// 9    10   11   12
// 13   14   15   16
// */
// P163Test(4, 4);

// /*
// 1    2    3    4    5
// 6    7    8    9    10
// 11   12   13   14   15
// 16   17   18   19   20
// 21   22   23   24   25
// */
// P163Test(5, 5);

// /*
// 1
// 2
// 3
// 4
// 5
// */
// P163Test(1, 5);

// /*
// 1    2
// 3    4
// 5    6
// 7    8
// 9    10
// */
// P163Test(2, 5);

// /*
// 1    2    3
// 4    5    6
// 7    8    9
// 10   11   12
// 13   14   15
// */
// P163Test(3, 5);

// /*
// 1    2    3    4
// 5    6    7    8
// 9    10   11   12
// 13   14   15   16
// 17   18   19   20
// */
// P163Test(4, 5);

// /*
// 1    2    3    4    5
// */
// P163Test(5, 1);

// /*
// 1    2    3    4    5
// 6    7    8    9    10
// */
// P163Test(5, 2);

// /*
// 1    2    3    4    5
// 6    7    8    9    10
// 11   12   13   14    15
// */
// P163Test(5, 3);

// /*
// 1    2    3    4    5
// 6    7    8    9    10
// 11   12   13   14   15
// 16   17   18   19   20
// */
// P163Test(5, 4);

// ====================================================================================
// P166StackMin

// var stack = new P166StackMin();

// stack.Push(3);
// P166Test("Test1", stack, 3);

// stack.Push(4);
// P166Test("Test2", stack, 3);

// stack.Push(2);
// P166Test("Test3", stack, 2);

// stack.Push(3);
// P166Test("Test4", stack, 2);

// stack.Pop();
// P166Test("Test5", stack, 2);

// stack.Pop();
// P166Test("Test6", stack, 3);

// stack.Pop();
// P166Test("Test7", stack, 3);

// stack.Push(0);
// P166Test("Test8", stack, 0);

// ====================================================================================
// P176BreadthFirstPrintTree
// P176BreadthFirstTest1();
// P176BreadthFirstTest2();
// P176BreadthFirstTest3();
// P176BreadthFirstTest4();
// P176BreadthFirstTest5();
// P176LayeredBreadthFirstPrintTreeTest1();
// P176LayeredBreadthFirstPrintTreeTest2();
// P176LayeredBreadthFirstPrintTreeTest3();
// P176LayeredBreadthFirstPrintTreeTest4();
// P176LayeredBreadthFirstPrintTreeTest5();
// P176LayeredBreadthFirstPrintTreeTest6();
// P176ZigZagBreadthFirstPrintTreeTest1();
// P176ZigZagBreadthFirstPrintTreeTest2();
// P176ZigZagBreadthFirstPrintTreeTest3();
// P176ZigZagBreadthFirstPrintTreeTest4();
// P176ZigZagBreadthFirstPrintTreeTest5();
// P176ZigZagBreadthFirstPrintTreeTest6();
// P176ZigZagBreadthFirstPrintTreeTest7();

// ====================================================================================
// P180IsArrayBST
// P180Test1();
// P180Test2();
// P180Test3();
// P180Test4();
// P180Test5();
// P180Test6();
// P180Test7();
// P180Test8();

// ====================================================================================
// P183TreePathSum
// P183Test1();
// P183Test2();
// P183Test3();
// P183Test4();
// P183Test5();
// P183Test6();

// ====================================================================================
// P187CopyComplexList
// P187Test1();
// P187Test2();
// P187Test3();
// P187Test4();
// P187Test5();

// ====================================================================================
// P190ConvertTreeToList
// P190Test1();
// P190Test2();
// P190Test3();
// P190Test4();
// P190Test5();

// ====================================================================================
// P191DeserializeTree
// P191Test1();
// P191Test2();
// P191Test3();
// P191Test4();
// P191Test5();
// P191Test6();

// ====================================================================================
// P198LengthNCombination("abcd".ToArray(), 3);
// P198Combination("abcd".ToArray());

// ====================================================================================
// P205NumberOverHalf("abcd".ToArray(), 3);
// P205Test1();
// P205Test2();
// P205Test3();
// P205Test4();
// P205Test5();
// P205Test6();

// ====================================================================================
// Test Red-Black Tree
// RBTreeNode<int>? root = null;
// RBTreeNode<int>.Insert(ref root, 1);
// RBTreeNode<int>.Insert(ref root, 6);
// RBTreeNode<int>.Insert(ref root, 3);
// RBTreeNode<int>.Insert(ref root, 9);
// RBTreeNode<int>.Insert(ref root, 3);
// RBTreeNode<int>.Insert(ref root, 10);
// RBTreeNode<int>.Insert(ref root, 3);
// RBTreeNode<int>.Insert(ref root, 5);
// RBTreeNode<int>.Insert(ref root, 6);
// RBTreeNode<int>.Insert(ref root, 7);
// RBTreeNode<int>.Insert(ref root, 2);
// RBTreeNode<int>.Insert(ref root, 14);
// RBTreeNode<int>.Insert(ref root, 15);
// RBTreeNode<int>.Insert(ref root, 11);
// RBTreeNode<int>.Insert(ref root, 12);

// TreeNode<int>.Print2D(root);

// ====================================================================================
// P210LeastKNumbers
// P210Test1();
// P210Test2();
// P210Test3();
// P210Test4();
// P210Test5();
// P210Test6();
// P210Test7();

// ====================================================================================
// P215MedianOfStream
// P215Test();

// ====================================================================================
// P220MaxSubArraySum
// P220Test1();
// P220Test2();
// P220Test3();
// P220Test4();

// ====================================================================================
// P222Count1s
// P222Test();

// ====================================================================================
// P225NthNumber
// P225Test();

// ====================================================================================
// P230MinNumCombo
// P230Test();

// ====================================================================================
// P232Num2Alpha
// P232Test();

// ====================================================================================
// P235MaxRightDownPath
// P235Test();

// ====================================================================================
// P236MaxUniqueStr
// P236Test();

// ====================================================================================
// P243NthUglyNumber
// P243Test()

// ====================================================================================
// P244NonDupChar
// P224Test01();
// P224Test02();

// ====================================================================================
// P250CountInversePairs
// P250Test();

// ====================================================================================
// P263CountAppearance
// P263Test();

// ====================================================================================
// P266FindMissing
// P266Test();

// ====================================================================================
// P268KthNodeOfBST
// P268Test();

// ====================================================================================
// P271TreeDepth
// P271Test();

// ====================================================================================
// P272IsTreeBalanced
// P272Test();

// ====================================================================================
// P277NumAppearOnce
// P277Test();


// ====================================================================================
// P278NumAppearOnceOthers3
// P278Test();

// ====================================================================================
// P284ReverseSentenceWord
// P284ReverseSentenceWord("yahaha wuhuhu.");
// P284Test();

// ====================================================================================
// P280SumOfEle
// P280Test();

// ====================================================================================
// P282SeqSum
// P282Test();

// ====================================================================================
// P286LeftRotateWord
P286Test();
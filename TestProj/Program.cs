// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using static Algorithm.Chapter2.Solution;
using static Algorithm.Chapter3.Solution;

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
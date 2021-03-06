# 类与对象

1. 类是对现实事物进行抽象(建模)的结果而**对象是类的实例化**(普遍性与特殊性)

2. 建模是一个去伪存真的过程，*（取其精华去其糟粕，“具体问题具体分析“）*

3. 用new创建类的实例(对象)
4. 引用变量与实例的关系(比较像指针)

## 类的三大成员

1. 属性：储存数据，结合起来表示对象的状态

2. 方法：表示类/对象能做什么->构成逻辑的成员

3. 事件：C#特有(触发机制如Click)

   

## 特殊类/对象在成员方面侧重点不同

1. 模型对象侧重属性 如Entity Framework
2. 工具对象侧重方法 如Math，Console
3. 通知类对象重在事件 如Timer

## 静态成员与实例成员

1. 静态(Static)从语义上是类的成员(**也称共享成员，在类的实例之间共享   类名.静态成员**)

2. 实例是对象的成员(**对象名.实例成员**)

3. 什么时候使用静态成员：①变量需要被共享的时候②方法需要被反复的调用的时候

4. 在MSDN中有<font color='red'>S</font>的是静态成员

5. 绑定(Binding):编译器把一个成员与类/对象关联起来

   ##### 编译的时候binding 为早绑定     运行的时候绑定为晚绑定称为动态语言

###### 当类第一次被加载的时候（就是该类第一次被加载到内存当中），该类下面的所有静态的成员都会被加载。实例成员有多少对象，就会创建多少对象。而静态成员只被加载到静态存储区，只被创建一次，且直到程序退出时才会被释放。
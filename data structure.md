[TOC]

# 数据结构



***定义***：数据结构是相互之间存在一种或多种特定关系的数据元素的集合

数据项是数据的最小单位

几种结构：

1. 集合结构   各数据元素之间平等

2. 线性结构   一对一

3. 树状结构   一对多

4. 图像结构   多对多

   

### 算法

***定义***：算法是解决特定问题求解步骤的*描述*，编程中表现为指令的有限序列

五个基本特征

1. 输入：可以无输入或多个
2. 输出：一个或多个
3. 有穷性：可跳出 在可接受的时间内运行
4. 可行性
5. 确定性  四个层次：
   1. 没有语法错误
   2. 对于合法输入能够产生满足要求的输出结果
   3. 非法的·输入有满足规格说明的结果
   4. 对于刁难的测试数据都有满足要求的输出结果

代码要有的特性：

1. 可读性
2. 健壮性 参考③👆
3. 时间效率高
4. 存储量低

### 测试运行时间的可靠方法(事前分析估算法)：

计算对运行时间有消耗的基本操作的执行次数。运行时间与这个计数成正比

函数的渐近增长：给定连个函数F(n)与G(n),如果存在一个证书N，使得对于所有n>N,F(n)总大于G(n)，F(n)的增长渐快于G(n)
还有事后统计方法(不科学、不准确)
### 大O记法

1. 基本操作的数量必须表示成输入规模的函数如f(n)=n
2. 算法时间复杂度T(n)=O(f(n)) ,f(n)为算法规模n的某个函数，T(n)增长越慢，越优
3. O(1)为常数阶 O(n)为线性阶 O(n^2^)为平方阶

### 推导大O阶

1. 用常数1取代运行时间中所有的加法常数
2. 在修改后的运行函数次数中，只保留最高阶项
3. 如果最高项阶数有且不为1，去除它的系数

对于分支结构，执行次数恒定，不受输入规模n的影响，时间复杂度也为O(1)

对数阶

~~~C
while（count<n)
    count*=2;
~~~

∴2^x^=n  ∴x=log~2~n 则其时间复杂度为O(log~2~n)
### 空间复杂程度比较
S(n)=O(f(n))    n为问题的规模  f(n)为语句关于n所占储存空间函数
O(1)<O(log~a~n)<O(n)<O(n*log~a~n)<O(n^2^)<O(n^3^)<O(2^n^)<O(n!)<O(n^n^)\

### 递归

1. 定义：在高级语言中，调用自己和其他函数并没有本质的区别。我们把一个直接调用自己或通过一系列的调用语句间接地调用自己的函数，称为递归函数。

2. 每个递归定义必须至少有一个条件(防止无限递归)用作退出

   **迭代使用的是循环结构，而递归使用的是选择结构**，使程序的结构更清晰、更简洁

   但使用大量的递归调用会建立函数的副本，耗费大量的时间和内存

3. 递归过程的返回的顺序是它前行顺序的逆序

## 线性表

### 线性表的顺序储存结构

1. 定义：零个或多个数据元素组成的有限序列(数据类型相同)

2. a~1~、a~2、~……、a~i-1~、a~i~、a~i+·~、……、a~n~中

   a~i-1~是a~i~的前驱元素  a~i+·~是a~i~的后驱元素  直接前驱\后驱都是唯一的

   个数n(n>=0)定义为线性表的长度 n=0是为空表

   a~1~为第一个元素，a~n~为最后一个元素，则i为a~i~在线性表中的位序

3. **向函数传递参数 指针可改变参数 直接传递参数则不可改**
4. 顺序储存结构(含数组)包含的三个属性
   1. 起始位置
   2. 最大储存容量(数组长度)
   3. 当前长度

~~~C
#define MAXSIZE 20
struct
{
    int date[MAXSIZE];//<--数组长度
    int length;//<--线性表长度
    //MAXSIZE>>length
}
~~~

5. 地址计算方法

   数组从0开始，第i个元素在i-1项(假设LOC()为获取函数地址的函数)

   LOC(a~i+1~)=LOC(a~i~)+sizeof(a的类型)   <-----O(1)

#### 插入算法思路

   

   1. 插入位置不合理             ----->异常
   2. length>MAXSIZE          ----->异常或动态增加容量
   3. 从最后一个往前遍历 向后移动
   4. 插入    length++

      ~~~C
      //实现：
      //Initial condition：顺序线性表已存在且1<=i<=length
      //result：在第i项插入e.length++
          struct
          {
             int data[MAXSIZE];
             int length;
          }List;
          Bool ListInsert(List*L,int i,int e)
      {
          int k;
          if(L->length==MAXSIZE)  return false;
          if(i<1||i>L->length+1)  return false;
          if(i<=L->length)
          {
              for(k=L->length-1;k>=i-1;k--)
                  L->data[k+1]=L->data[k];
              L->data[i-1]=e;
              L->length++;
              return true;
          }
          
      }
      ~~~

   时间复杂度为O(n)

#### 删除算法的思路



1. 删除位置不合理             ----->异常
2. 取出删除元素
3. 从删除位置开始往后遍历 向前移动一个位置
4. 删除    length--

~~~C
//实现：
//Initial condition：顺序线性表已存在且1<=i<=length
//result：删除第i个数据元素.length--
    struct
    {
       int data[MAXSIZE];
       int length;
    }List;
    Bool ListDelete(List*L,int i)
{
    int k;
    if(L->length==0)  return false;
    if(i<1||i>L->length)  return false;
    if(i<=L->length)
    {
        for(k=i-1;k<=length;k++)
            L->data[k]=L->data[k+1];
        L->length--;
        return true;
    }
    
}
~~~



时间复杂度为O(n)

7. 存储或删除数据时时间复杂度都为O(1)而插入或删除时时间复杂度都为O(n)

#### 顺序储存结构的优缺点

|                优点                | 缺点                                         |
| :--------------------------------: | -------------------------------------------- |
| 无需为元素之间逻辑关系增加储存空间 | 插入和删除需要移动大量元素                   |
|      可以快速存取表中任意元素      | 线性长度变化较大时难以确定容量，浪费储存空间 |





### 线性表链式存储结构

结点(node)由数据域与指针域组成，指针域存储的是后继结点的地址

第一个结点的地址称为头指针，最后一个结点的指针域为NULL

通常在第一个结点之前附设一个头结点(可不存储数据，但也可以存储链表长度)

#### 头指针与头结点的异同

| 头指针                                                       | 头结点                                                       |
| ------------------------------------------------------------ | ------------------------------------------------------------ |
| 头指针是指向第一个结点的指针，如果有头结点，则是指向头结点的指针 | 为了操作的统一和方便而设立，数据与一般无意义，但也可存储链表长度 |
| 头指针具有标识作用，常用头指针冠以链表的名字                 | 有了头结点，第一个结点与其他结点的插入与删除的操作可以统一   |
| 无论链表是否为空，头指针均不为空，头指针是链表必要元素       | 头结点不一定是链表必要元素                                   |

~~~C
typedef struct Node
{
    ElemType data；               //->数据域
    struct Node* next；           //->指针域
}Node；
 typedef struct Node* LinkList;    //->头指针
~~~

#### 获取链表第i个数据的算法思路

1. 声明一个指针p指向链表的第一个结点，初始化j从1开始
2. 当j<i时遍历链表，指针p向后移动，j++
3. 若最终p为NULL，则说明第i个结点不存在
4. 查找成功则返回该结点的数据p->data

~~~C
//实现：
//Initial condition：单链表表已存在且1<=i<=Listlength(L)
//result：用e返回第i个结点的数据
Bool GetElem(LinkList L,int i,ElemType *e)
{
    LinkList p;
    p=L->next;
    while(p&&j<i)
    {
        p=p->next;
        ++j;
    }
    if(!p||j>i)  return false;
    *e=p->data;
    return true;
} 
~~~

***核心思想：工作指针后移***

最坏情况 时间复杂度为O(n)

#### 单链表第i个元素插入结点的算法思路

1. 声明一个指针p指向链表头结点，初始化j=1

2. 当j<i时，遍历链表，让p向后移动j++

3. 若p为NULL，说明第i个结点不存在

4. 查找成功，在系统中生成一个空结点s

5. 将数据元素e复制给s->data

6. 单链表插入标准语句：

   ~~~C
   s->next=p->next;
   
   p->next=s;  //顺序不能调换，否则会丢失指针
   ~~~

   ~~~C
   //实现：
   //initial condition：单链表L已存在，1<=i<=Listlength(L)
   //result: L中的第i个结点位置之前插入新的数据元素e，Listlength(L)++
   Bool ListInsert(LinkList *L,int i, ElemType e)
   {
       LinkList p,s;
       p=*L;
       int j=1;
       while(p&&j<i)
       {
           p=p->next;
           ++j；
       }
       if（!p||j>i) return false; //j>1防止i<1
       s=(LinkList*)malloc(sizeof(Node));
       s->data=e;
       s->next=p->next;
       p->next=s;
       return tue;
   }
   ~~~

   时间复杂度O(n)

#### 单链表第i个数据删除结点的算法思路

1. 声明一个指针p指向头结点，初始化j=1

2. 当j<i时遍历单链表，指针p向后移动，j++

3. 若p=NULL,说明第i个结点不存在

4. 若查找成功，则声明一个指针q储存要删除的结点

   且q=p->next

5. p->next=q->next;
6. 将q结点中的数据赋值给e返回
7. 释放q结点

~~~C
//实现：
//Initial condition：单链表L已存在，1<=i<=ListLength(L)
//result: 删除L的第i个结点，并用e返回其值，ListLength(L)--
Bool ListDelete(LinkList *L,int i,ElemType *e)
{
    int j=1;
    LinList p,s;
    p=*L;
    while(j<i&&p->next)
    {
        p=p->next;
        ++j;
    }
    if(j>i||!(p->next)) return false;
    q=p->next;
    p->next=q->next;
    *e=q->data;
    free(q);
    return true;
}
~~~

时间复杂度O(n)

#### 初始化单链表

~~~C
typedef struct Node
{
    ElemType data；               //->数据域
    struct Node* next；           //->指针域
}Node；
 typedef struct Node* LinkList;  //LinkList是头指针类型
LinList *L;                //头指针的指针，方便传递以修改链表
*L=NULL；

~~~



#### 单链表的整表创建的算法思路

1. 声明一个指针p和计数变量i
2. 初始化一个空链表L
3. 让L的头结点的指针指向NULL
4. 循环
   1. 生成一个新结点赋值给p
   2. 随机生成一个数给p的数据域赋值
   3. 将结点放到末尾

~~~C
void CreateList(LinkList* L,int n)
{
    LinkList p,new;
    int i;
    srand(time(0));
    *L=(LinkList)malloc(Node);
    n=*L;
    for(i=0;i<n;i++)
    {
        p=(LinkList)malloc(sizedof(Node));
        p->data=rand()%100+1;//随机生成100以内的数
        n->next=p;
        new=p;
    }
    new->next=NULL;
}
~~~

#### 单链表的整表删除算法思路

1. 声明一个指针p和q
2. 将第一个结点赋值给p
3. 循环：
   1. 将下一个结点赋值给q
   2. 释放p
   3. 将q赋值给p

~~~C
Bool ClearList（LinkList* L）
{
    LinkList p,q;
    p=*L;
    while(p)
    {
        q=p->next;
        free(p);
        p=q;
        
    }
    (*L)->next=NULL;
    return true;
}
~~~

#### 单链表结构(c1)Vs顺序储存结构(c2)

|           储存分配方式           |              时间性能              |                         空间性能                         |
| :------------------------------: | :--------------------------------: | :------------------------------------------------------: |
|         c2用一段储存单元         |   查找：<br /> c1:O(1)   c2:O(n)   | c1需要预先分配储存空间，<br />分大了，浪费，分少了，溢出 |
| c1采用链式储存结构，储存单元任意 | 插入和删除:<br />c1:O(n)   c2:O(1) |  单链表不需要预先分配储存空间，<br />元素个数也不受限制  |

结论：

1. 如果线性表需要频繁查找，很少进行插入删除操作，应采用顺序存储结构，反之则应采用单链表结构
2. 线性表中个数较大或者不知大小时，应用单链表结构，无需考虑存储空间的大小问题，反之亦然

### 静态链表

1. 用数组代替指针，创建一个结构体数组，data储存数据，cur储存后继元素的下标，cur称为游标

2. 第一个元素与最后一个元素不存储数据

3. 第一个元素，即下标为0的元素的cur储放第一个元素的下标(1)

4. 最后一个***有值***元素的游标为0，而数组最后一个元素游标为第一个元素的下标，相当于单链表中的头结点作用，当链表为空时为0

   ***李姐***：备用链表的第一个元素的下标为为L[0].cur,数据链表第一个元素下标为L[MAXSIZE-1].cur

#### 初始化静态链表

   ~~~C
   #define MAXSIZE 1000
       typedof struct
   {
       ElemType data;
       int cur;        
   }Component;
   Component space[MAXSIZE];
   //组成一条备用链表
   Bool InitList(Component space)
   {
       int i;
       for(i=0;i<MAXSIZE;i++)
           space[i].cur=++i;
       space[MAXSIZE-1].cur=0;
       return true;
   }
   ~~~

#### 静态链表的插入

   1. 原理：为了辨明哪些分量未被使用，将所有未被使用过的以及已经删除的份量用游标链成一个备用的链表，每次插入，从备用链表上取得第一个结点作为新结点

      ~~~C
      //若备用链表非空，则返回分配的结点下标，否则返回0
      int Malloc_SLL(Component space)
      {
          int  i=space[0].cur;
          if(space[0].cur)
              space[0].cur=space[i].cur;
          return i;
      }
      //在第i个元素之前插入新的数据元素e
      Bool ListInsert(Component L,int i,ElemType e)
      {
          int j,k,l;
          k=MAXSIZE-1;
          if(i<1||i>ListLength(L)+1) return false;
          j=Malloc_SLL(L);//获得空闲分量的下标
          if(j)
          {
              L[j].data=e;
              for(l=1;l<=i-1;l++)
                  k=L[k].cur;//k是最后一个元素，存储的第一个有值元素的
              L[j].cur=L[k].cur;
              L[k].cur=j;
              return true;
          }
          reture false;
      }
      ~~~
      
      

#### 静态链表的删除操作

~~~C
//删除L中的第i个数据
Bool ListDelete(Component L,int i)
{
    int j,k;
    if(i<1||i>ListLength[L]) return false;
    for(j=MAX_SIZE-1;j<=i-1;j++)
       k=L[k].cur;
    j=L[k].cur;
    L[k].cur=L[j].cur;
    free_SSL(L,j);
    return true;   
}
void Free_SSL(Component space,int k)
{
    space[k].cur=space[0].cur;
    space[0].cur=k;
}
//返回L中数据个数
int ListLength(Component L)
{
    int j=0;
    int i=L[MAXSIZE-1].cur;
    while(i)
    {
        i=L[i].cur;
        j++;
    }return j;
}
~~~

#### 静态链表优缺点

|                             优点                             |                     缺点                     |
| :----------------------------------------------------------: | :------------------------------------------: |
| 在插入与删除操作时，只需要修改游标，<br />不需要移动元素从而改进了顺序储存结构中的需要移动大龄啊元素的缺点 | 没有解决连续储存分派带来的表长难以确定的问题 |
|                              /0                              |       失去了顺序储存结构随机存取的特性       |

ALL in ALL：静态链表是给没指针的高级语言设计的一种实现单链表能力的方法

### 循环链表

与单链表的差异：循环的判定上：单链表判断p->next是否为NULL，循环链表则是判断p->next!=头结点，不结束

有了头结点，需要O(1)时间访问第一个系欸但，对于最后一个结点则需要O(n)的时间

**如果想要以O(1)访问最后一个结点：不用头指针，用指向终端结点的指针来表示选好链表**

**a~1~->a~2~->a~3~->················->a~n~<-尾指针 而a~n~->a~1~,如果要合并两个循环链表，头尾相连即可 **

### 双向链表

为了使前后查找下一结点的时间复杂度都为O(1),双向链表在每一个结点中都设置两个指针域，一个指向前继，一个指向后继

~~~C
typedef struct DulNode
{
    ElemType data;
    stuct DuLNode *prior;
    struct DuLNode *next;    
}DulNode,*DuLinkList;
~~~

***双向链表中也可采用循环链表***，因为有前继指针，可以直接采用有头指针的循环链表结构

双向链表可以有反方向遍历的数据结构但是，在添加或删除结点的时候需要修改两个指针变量

~~~C
//设储存元素e的结点为s，要实现将s插入到结点p与结点p->next之间
s->prior =p;
s->next =p->next;
p->next->prior=s;
p->next=s; 
//顺序 先完成s的前驱以及后驱，再搞定后结点的前驱，最后搞定前结点的后驱
~~~

~~~C
//要删除结点p
p->prior->next=p->next;
p->next->prior=p->prior;
free(p);//顺序没特别要求
~~~

### 栈与队列

|      栈      |   队列   |
| :----------: | :------: |
|    顺序栈    | 顺序队列 |
| 两栈共享空间 | 循环队列 |
|     链栈     |  链队列  |



1. 栈的定义：**栈**是限定只能在表尾进行插入与删除操作的线性表，允许插入和删除的一端叫栈顶，另一端则为栈底，不含任何数据的叫空栈。栈又称为“后进后出”的线性表，栈的插入操作(push)叫进栈，也叫压栈、入栈，栈的删除操作(pop)叫出栈，也叫弹栈

   在不是所有元素都进栈的情况下，事先进去的栈也可以出栈，只要保证是在栈顶就ok

   比如  1进，1出，2进，3进，3出，2出

2. **队列**是值允许在一端进行插入操作、在另一端进行删除操作的线性表

#### ADT 栈(stack)

1. Data：同线性表。相邻元素具有前驱和后继的关系

2. Operation

   InitStack(*S):初始化操作，建立一个空栈

   DestoryStack(*S):若栈存在，销毁

   ClearStack(*S):清空栈

   StackEmpty(S)：检验栈是否为空，若为空返回true，否则返回false

   GetTop(S,*e):若栈存在且非空,用e返回S的栈顶元素

   Push(*S,e):若栈存在，插入新元素e到栈中

   Pop(**S*,*e):删除栈S中的栈顶元素，并用e返回其值   

   StackLength(S):返回栈中元素个数

   **下标为0的一端作为栈底，定义一个top指示栈顶元素的位置，top<StackSize,top=0时栈有一个元素，因此空栈的判断条件时top=-1**
   
   ~~~C
   //栈的结构定义
   typedef int SElemType;//假设数据类型为int
   typedef struct
   {
       SElemType data[MAXSIZE];
       int top;
   }SqStack;
   ~~~
   

#### 栈的顺序储存结构及实现

##### 进栈与出栈操作

###### 进栈操作

   ~~~C
   Bool Push(SqStack *S,SElemType e)
   {
       if(S->top==MAXSIZE-1)
           return false;
       s->top++;
       S->data[S->top]=e;
       return true; //先提高栈的“容量”
   }
   ~~~

###### 出栈操作

   ~~~C
   Bool Pop(SqStack *S,SElemType *e)
   {
       if(S->top==-1)
           return flase;
       *e=S->data[S->top];
       S->top--;
       return true;    
   }
   ~~~

   时间复杂度都为O(1)

但栈用的时数组储存数据，一样有数组大小难以确定的缺陷，因此使用一个数组来储存两个相同类型的栈(合租)

​          两个栈的栈底分别为下标为0处以及下标为n-1处，空栈分别表现为top1=-1，top2=n 栈顶双向奔赴

​          栈满：top1+1=top2

​       

##### 两栈共享空间结构

但栈用的时数组储存数据，一样有数组大小难以确定的缺陷，因此使用一个数组来储存两个相同类型的栈(合租)

两个栈的栈底分别为下标为0处以及下标为n-1处，空栈分别表现为top1=-1，top2=n 栈顶双向奔赴，***通常两个栈的空间需求具有相反关系时才有比较大的意义，不然一样很快溢出***

栈满：top1+1=top2

***前提条件***：两个栈具有相同的数据类型

~~~C
typedef struct
{
    SElemType data[MAXSIZE];
    int top1;
    int top2;
}SqDoubleStack;
~~~

###### 进栈操作

比单栈多了一个StackNumber，判断是加入到栈1还是栈2

~~~C	
Bool Push(SqDoubleStack *S,SElemType e,int StackNumber)
{
    if(S->top1+1==S->top2)
        return false;
    if(StackNumber==1)
    {
        top1++;
        S->data[S->top1]=e;
    }
    if(StackNumber==2)
    {
        top1--;
        S->data[S->top2]=e;
    }
}
~~~

###### 出栈操作

~~~C
Bool Pop(SqDoubleStack *S,SElemType *e,int StackNumber)
{
    if(stackNumber==1)
    {
        if(S->top1==-1)
            return false;
        *e=S->data[top1--];
    }
    else if(StackNumber==2)
    {
        if(S->top2==n)
            return false;
        *e=S->data[top2++];
    }
    return true;
}
~~~

#### 栈的链式存储结构及实现

链栈不存在栈满的情况，除非内存寄了

##### 链栈的结构

~~~C
typedef struct StackNode//StackNode不是结构体名(struct StackNode),因为要套娃，typedef还没用，需要一个ID
{
    SelemType data;
    struct StackNode *next;
}StackNode, *LinkStackPtr;
typedef struct 
{
    LinkStackPtr top;
    int count;
}LinkStack;
~~~

##### 进栈操作

~~~C
Bool Push(LinkStack *S,SElemType e)
{
    LinkStackPtr s=(LinkStackPtr)malloc(sizeof(StackNode));
    s->data=e;
    s->next=S->top;
    S->top=s;
    S->count++;
    return true;
}
~~~

##### 出栈操作

~~~C
Bool Pop(LinkStack *S,SElemType *e)
{   if(S->count==0)//if(StackEmpty(*S))
             return false;
    LinkStackPtr p;
    *e=S->top->data;
    p=S->top;
    S->top=S->top->next;
    free(p);
    S->count--;
    return true;
}
~~~

时间复杂度均为O(1)

#### 对比顺序栈与链栈

1. 时间复杂度均为O(1)
2. 顺序栈需要事先知道一个长度，存在空间浪费问题，优势是存取时方便
3. 链栈要求每个元素都有指针域，增加了一些内存占用，但是对于栈的长度无限制

#### 栈的作用

栈的引入简化了程序设计的问题，不用像数组一样过多去关注下标增减等细节问题，使得思考范围减少，而且Java、C#等都有对栈的封装，很方便

#### 栈的应用

##### 1.在程序设计语言中实现了[递归](#递归)

**在退回过程中，可能要执行某些动作(包括回复在前行中储存起来的某些数据)：**

在前行阶段，对于每一层递归，函数的局部变量、参数值、以及返回地址都被压入栈中。在退回阶段，位于栈顶的局部变量、参数值和返回地址被弹出，用于返回调用层次中执行代码的其余部分

不过对于高级语言来说，由系统管理这个栈

##### 2.四则运算表达式求值

1. 将中缀表达式转化为后缀表达式
2. 将后缀表达式进行运算(这里栈用来进出运算的数字)

###### 后缀(逆波兰)表示法定义

对于"9+(3-1)×3+10/2",用后缀表示法："9 3 1-3×+10 2/+"

规则：从左到右遍历表达式的每个数字和符号，遇到数字就进栈，遇到符号就将处于栈顶的两个数字出栈，进行运算，运算结果进栈。直到最终获得结果

###### 中缀表达式转后缀表达式

平时使用的"9+(3-1)×3+10/2"称为中缀表达式

***转为后缀表达式的规则：***

从左到右遍历中缀表达式的每个数字和符号，若是数字就输出，称为后缀表达式的一部分。若是符号，则判断其与栈顶符号的优先级，是右括号或优先级**不高于(<=)**栈顶符号(乘除优先加减)则将栈顶元素依次出栈并输出[当判断为')'时，直到'('出栈为止]，并将当前符号进栈，一直到最终输出后缀表达式为止(遍历完后依次出栈)

#### 队列

1. 死机的时候，要等计算机酒醒了之后才会进行刚刚死机的所有操作，而客服系统是上一个客户结束之后再接下一个。操作系统与客服系统中，都应用了一种数据结构来实现先进先出的排队系统------队列

2. ***队列的定义：***只允许在一端进行插入操作，而在另一端进行删除操作的线性表

   即先进先出(First in First Out),简称FIFO的线性表

3. 允许插入的一端称为队尾，允许删除的一端称为队头

#### ADT 队列(Queue)

Data:同线性表。元素具有相同的类型，相邻元素具有前驱后后继关系

Operation：

~~~C
Qperation：
InitQueue(*Q)：初始化操作，建立一个空队列Q
DestroyQueue(*Q)：若队列Q存在，销毁
ClearQueue(*Q)：将队列Q清空
QueueEmpty(Q):若队列为空，返回true，否则返回false
GetHead(Q,*e):若队列Q存在且非空，用e返回队列Q的队头元素
EnQueue(*Q,e):若队列Q存在，插入新元素e到队列Q中并成为队尾元素
DeQueue(*Q,*e):删除队列Q中的队头元素，并用e返回其值ueueLength(*Q):返回队列Q的元素个数
~~~

#### 顺序储存结构以及实现循环队列的优化

##### 队列顺序存储的不足

1. 入队列的操作只需在队尾增加一个元素，时间复杂度为O(1)

   出列使在队头，即下标为0的位置，所有元素都得向前移动，保证队头不为空，时间复杂度为O(n)

2. 而如果不限制队列的元素必须存储在数组的前n个单元，出队性能将会大大提高

   但为了避免只有一个元素的时候，队头与队尾重合，引入两个指针，front指针指向队头元素，rear指针指向队尾元素的下一位置，当front=rear时为空队列，但是如果队列容易假溢出(队列前面还有空间，但是不用)，队列后端满的时候，rear就会指向数组外

##### 循环队列的定义

后面满了就从头再来，即头尾相接的循环，rear改为指向下标为0的位置，但是队列满了的时候还是会出现front=rear的情况，无法判断是队列为空还是满

1. 设置一个标志变量flag，当front==rear，且flag=0时队列为空

   当front==rear且flag=1时队列为满

2. 当队列为空时，条件为front=rear，当队列为满时修改其条件，保留一个元素空间，即队列未满时，数组里面还存在一个空闲单元

   如果队列的**最大尺寸**为QueueSize，则队列满的条件为***==(rear+1)%QueueSize======front==***

   **李姐**：如果rear在front前面，则rear+1<QueueSize,即rear+1==front

   ​             如果rear在front后面则rear+1=QueueSize，且front=0。

   

   因此通用的队列长度公式为：***==(rear-front+QueueSize)%QueueSize==***

   当rear>front时，队列长度为rear-front

   而当rear<front时  队列长度为QueueSize-front+rear(总小于QueueSize)
   
   指针到最后的判定：==(Q->rear(或front)+1)%QueueSize==，数组最后一位为QueueSize-1

##### 循环队列的顺序储存结构

~~~C
//假定QElemType类型为int
tyepdef int QElemType;
typedef struct
{
    QElemType data[MAXSIZE];
    int front;//头指针
    int rear;//尾指针，若队列不为空，则指向队列尾元素的下一位置
}SqQueue;
~~~

##### 循环队列的初始化

~~~C
Bool InitQueue(SqQueue *Q)
{
    Q->front=0;
    Q->rear=0;
    return true;
}
~~~

##### 求队列当前长度

~~~C
int QueueLength(SqQueue Q)
{
    return(Q.rear+MAXSIZE-Q.front)%MAXSIZE;
}
~~~

##### 入队列操作

~~~C
Bool EnQueue(SqQueue *Q,QElemType e)
{
    if((Q->rear+1)%MAXSIZE==Q->front)
        return false;
    Q->data[Q->rear]=e;
    Q->rear=(Q->rear+1)%MAXSIZE;//rear指针向后移动，若到最后则转到数组头部
    return true;
}
~~~

##### 出队列操作

~~~C
Bool DeQueue(SqQueue *Q,QElemType *e)
{
    if(Q->rear==Q->front)
        return false;
    *e=Q->data[Q->front];
    Q->front=(Q->front+1)%MAXSIZE;//若到最后则转到数组头部
    return OK;
}
~~~



单是顺序储存结构，时间性能并不高，但是循环队列又可能溢出

#### 链式储存结构及实现

队列的链式储存结构即线性表的单链表，不过只能尾进头出，为了操作上的方便，将队头指针指向链队列的头结点，队尾指针指向终端结点。*空队列时，front和rear都指向头结点*(头结点不存储数据)

##### 链队列的结构

~~~C
//假设QElemType类型为int
typedef int QElemType;
typedef struct 
{
    QelemType data;
    struct QNode *next;
}QNode,*QueuePtr;
~~~

##### 队列的链表结构

~~~C
typedef struct
{
    QueuePtr front;
    QueuePtr rear;
}LinkQueue;//用以操作的是头尾指针
~~~

##### 入队操作

~~~C
Bool EnQueue(LinkQueue *Q,QElemType e)
{
    QueuePtr s=(QueuePtr)malloc(sizeof(QNode));
    if(s==NULL) return false;
    s->data=e;
    s->next=NULL;
    Q->rear->next=s;
    Q->rear=s;
    return true; 
}
~~~

##### 出队操作

~~~C
Bool DeQueue(LinkQueue *Q,QElemType *e)
{
    if(Q->front==Q->rear)
        return false;
    QueuePtr p;
    p=Q->front->next;
    *e=p->data;
    Q->front=p->next;
    if(p==Q->rear)           //如果队头是队尾
        Q->rear=Q->front;
    free(p);
}
~~~

##### 链队列与循环队列的对比

|      |                 循环队列                 |            链队列             |
| ---- | :--------------------------------------: | :---------------------------: |
| 时间 |                   O(1)                   | O(1),不过申请空间增加时间开销 |
| 空间 | 固定的长度，存在储存个数和空间浪费的问题 |           更加灵活            |

ALL IN ALL：在可以确定队列长度最大值的情况下，用前者，否则用后者

#### 鸡汤
​        人生，就像一个很大的栈演变。出生时你赤条条地来人世，慢慢的长大，渐渐的变老，最终还得赤条条地离开人间

​        人生，又仿佛时一天一天小小地栈重现。童年父母每天抱着你不断地进出家门，壮年你每天奔波于家与事业之间，老年你每天肚子蹒跚于养老院地门前屋里

​        人生，更需要有进栈出栈精神地体现。在哪里跌倒，就应该在哪里爬起来。无论陷入何等困境，只要抬头能仰望蓝天，就有希望，不断进取，你就可以让出头之日重现。困难不会永远存在，强者才能勇往直前

​        人生，其实就是一个大大地队列演变。无知童年、快乐少年、稚傲青年、成熟中年、安逸晚年

​        人生，又是一个有一个小小的队列重现。春夏秋冬轮回年年，早中晚夜循环天天。变化是时间，不变地是你对未来执著地信念

​        人生，更需要有队列精神地体现。南极到北极，不过是南纬九十度到北纬九十度地队列，如果你中途犹豫，临时转向，也许你就说只能和企鹅相伴永远。可事实上，无论哪个方向，只要你坚持到底，你都可以到达终点



### 串

1. 定义：串时由零个或多个字符组成地有限序列，也叫字符串 
2. 一些概念：
   1. 字串与主串：串中任意个数地连续字符组成地子序列为该串地子串
   2. 字串在主串中的位置就是字串的第一个字符在主串中的序号
   3. 串的比较：逐个字符比较,前面都相等情况下，字符多为大
   4. 字符使用ACSCII编码，七位二进制
   5. Unicode时对ASCII编码的扩展，八位二进制，前256个字符与ASCII编码一样

#### 串的顺序存储结构

为每个定义的串变量分配一个固定长度的储存区。一般是用定长数组来定义

一般数组第一个位置或最后一个位置储存字符串的长度，也有的在串后面加一个‘\0’表示串值的终结，通过遍历来计算长度

#### 串的链式存储结构

与线性表类似，一个结点可以存储一个或多个字符，需要根据实际情况选择

但是串的链式存储结构除了能够在连接串与串的操作中方便一点，总体来说不如顺序存储结构灵活，性能也不如顺序存储结构

#### 朴素的模式匹配算法

对主串的每一个字符作为字串的开头，与要匹配的字符串进行匹配。对主串做大循环，每个字符开头做T的长度的小循环，直到匹配成功或全部遍历完为止

~~~C
//假设主串S与字串T的长度存储在S[0]与T[0]中
//返回字串T在主串S中第pos个字符之后的位置
//T非空，且1<=pos<=StrLength(S)
int Index(char S[],char T[],int pos)
{
    int i=pos;
    int j=1;
    while(i<=S[0]&&j<=T[0])
    {
        if(S[i]==T[j])
        {
            ++i;
            ++j;
        }
        else
        {
            i=i-j+2;//i增与j增相同，减去增加的，加上j初始的1，并向后移动一位
            j=1;
        }
    }
    if(j>T[0])
        return i-T[0];
    else 
        return 0;
}
~~~

n为主串长度，m为要匹配的字符串长度，平均是(n+m)/2次查找，时间复杂度O(n+m)，最坏情况O((n-m+1)*m)

#### KMP模式匹配算法

(克努特-莫里斯-普拉斯算法)

原理：主串S与要匹配的串T的前n(假设6)个字符都相等时，T中的首字符与T中后面的字符都不相等(前提)

S[1],S[2],S[3],S[4],S[5],S[6]

T[1],T[2],T[3],T[4],T[5],T[6]，仅有S[6]与T[6]不同，因为T[1]!=T[i],i=2,3,4,5,6因此T[1]!=S[i],i=2,3,4,5(6不行)

共6次比较(1、2、3、4、5、6)，只需保留(1、6)即可 

刚开始时令 j 指向模式串中第 1 个字符，i 指向第 2 个字.符。接下来，对每个字符做如下操作：

1. 如果 i 和 j 指向的字符相等，则 i 后面第一个字符的 next 值为 j+1，同时 i 和 j 做自加 1 操作，为求下一个字符的

   ![2-1Q2131ZAI94](D:\github\wuhu.first\2-1Q2131ZAI94.gif)

2. 字符 'a' 的 next 值为 j +1 = 2，同时 i 和 j 都做了加 1 操作。当计算字符 'C' 的 next 值时，还是判断 i 和 j 指向的字符是否相等，显然相等，因此令该字符串的 next 值为 j + 1 = 3，同时 i 和 j 自加 1（此次 next 值的计算使用了上一次 j 的值）

   ![2](D:\github\wuhu.first\2.gif)

3. 如上图所示，计算字符 'd' 的 next 时，i 和 j 指向的字符不相等，这表明最长的前缀字符串 "aaa" 和后缀字符串 "aac" 不相等，接下来要判断次长的前缀字符串 "aa" 和后缀字符串 "ac" 是否相等，这一步的实现可以用 j = next[j] 来实现，如图所示：

   ![3](D:\github\wuhu.first\3.gif)

4. 从上图可以看到，i 和 j 指向的字符又不相同，因此继续做 j = next[j] 的操作

   ![4](D:\github\wuhu.first\4.gif)

   

5. j = 0 表明字符 'd' 前的前缀字符串和后缀字符串相同个数为 0，因此如果字符 'd' 导致了模式匹配失败，则模式串移动的距离只能是 1

##### 模式串

***第一个字符对应的是0，第二个字符对应的是1***

~~~C
//next函数
void Next(char *T,int *next)
{
    next[1]=0;
    next[2]=1;
    int i=2;
    int j=1;
    while(i<strlen(T))
    {
        if(j==0||T[i-1]==T[j-1])
        {
            i++;
            j++;
            next[i]=j;
        }
        else{
            j=next[j];
        }
    }
}
~~~

代码中 j=next[j] 的运用可以这样理解，每个字符对应的next值都可以表示该字符前 "同后缀字符串相同的前缀字符串最后一个字符所在的位置"，因此在每次匹配失败后，都可以轻松找到次长前缀字符串的最后一个字符与该字符进行比较。

但遇到长一段的字符串时会出现一段一段缩短对比的情况如：

![5](D:\github\wuhu.first\5.gif)



~~~C
//改进，添加了在当T[i-1]==T[j-1] 成立时，继续对 i++ 和 j++ 后的 T[i-1] 和 T[j-1] 的值做判断
void Next(char*T,int *next){ 
    next[1]=0;
    next[2]=1;
    int i=2;
    int j=1;
    while (i<strlen(T)) {
        if (j==0||T[i-1]==T[j-1]) {
            i++;
            j++;
            if (T[i-1]!=T[j-1]) {
               next[i]=j;
            }
            else{
                next[i]=next[j];
            }
        }else{
            j=next[j];
        }
    }
}
~~~

##### KMP算法的实现

~~~C
//返回匹配成功的字符串中第一个字符的下标
int KMP(char *S,char*T)
{
    int next[M];//M为字符串T最大长度
    Next(T,next);
    int i=1;
    int j=1;
    while(i<=strlen(S)&&j<=strlen(T))
    {
        if(j=0||S[i-1]==T[j-1])
        {
            i++;
            j++;
        }
        else {
            j=next[j];//如果测试的两个字符不相等，i不动，j变为当前测试字符串的next值
        }
        
    }
    if(j>strlen(T))//匹配成功
    {
        return i-(int)strlen(T);//strlen()函数返回无符号整数
    }
    return -1;
}
//j==0:代表模式串的第一个字符就和当前测试的字符不相等；S[i-1]==T[j-1],如果对应位置字符相等，两种情况下，指向当前测试的两个指针下标i和j都向后移
~~~

## 树

1. 定义：一对多的数据结构，树是n(n>=0)个结点的有限集，n=0即为空数、

2. **有且仅有一个**特定的结点称为根(Root),n>1时，其余结点可分为m个**互不相交**的有限集，称为跟的子树(SubTree)

3. 结点拥有子树的数量称为结点的度(De-gree)。度为0的结点称为叶节点(Leaf)或者终端结点，度不为0的点称为分支节点或非终端节点。分支结点也叫内部节点(不包括根节点)。**树的度是树内结点的最大值**。
4. 结点的子树的根称为该结点的孩子(Child),倒过来则为双亲(Parent).同一个Parent的Child之间互称为兄弟(Sibling)

5. 根为第一层，根的最大层次称为根的深度(Depth)或者高度

6. 有序树(从左至右有次序)与无序树

7. 森林是m(m>=0)棵不相交的树的集合(m=0同空集)

   | 线性结构                     | 树结构                     |
   | ---------------------------- | -------------------------- |
   | 第一个数据元素无前驱         | 根结点：无双亲，唯一       |
   | 最后一个数据元素无后继       | 叶结点：无孩子，可以多个   |
   | 中间元素：一个前驱，一个后继 | 中间结点：一个双亲多个孩子 |

### 树的抽象类型数据

树中结点具有相同的数据类型与层次关系

~~~C
树的基本操作
Operation：
InitTree(*T)                          构造空树T
DestroyTree(*T)                       销毁树T
CreateTree(*T,definition)             按definition中给出的树的定义来构造树
ClearTree(*T)                         若树存在，将树清为空树
TreeEmpty(T)                          若树为空树，返回true，否则返回false
TreeDepth(T)                          返回树的深度
Root(T)                               返回T的根结点
Value(T,cur_e)                        返回树T中结点cur_e的值
Assign(*T,cur_e,value)                给树中的结点cur_e赋值为value
Parent(T,cur_e)                       若cur_e是树的非根结点，返回其双亲，否则返回空
LeftChild(T,cur_e)                    若cur_e是树的非叶结点，返回其最左孩子，否则返回空
RightSibling(T,cur_e)                 若cur_e有右兄弟，返回其右兄弟，否则返回空
Insert Child(*T,*p,i,c)               P指向树T中的某个结点，i为所指结点p的度加上1，插入c为树T中的第i棵子树
DeleteChild(*T,*p,i)                  p指向树T中的某个结点，i为所指结点p的值，删除T中p所指结点的第i棵子树
~~~


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
bool GetElem(LinkList L,int i,ElemType *e)
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
   bool ListInsert(LinkList *L,int i, ElemType e)
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
bool ListDelete(LinkList *L,int i,ElemType *e)
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
bool ClearList（LinkList* L）
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

单链表结构(c1)Vs顺序储存结构(c2)

|           储存分配方式           |              时间性能              |                         空间性能                         |
| :------------------------------: | :--------------------------------: | :------------------------------------------------------: |
|         c2用一段储存单元         |   查找：<br /> c1:O(1)   c2:O(n)   | c1需要预先分配储存空间，<br />分大了，浪费，分少了，溢出 |
| c1采用链式储存结构，储存单元任意 | 插入和删除:<br />c1:O(n)   c2:O(1) |  单链表不需要预先分配储存空间，<br />元素个数也不受限制  |

结论：

1. 如果线性表需要频繁查找，很少进行插入删除操作，应采用顺序存储结构，反之则应采用单链表结构
2. 线性表中个数较大或者不知大小时，应用单链表结构，无需考虑存储空间的大小问题，反之亦然


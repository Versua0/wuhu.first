***一、快慢指针***

:    遍历寻找单链表中的倒数某项

```c
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
int kthToLast(struct ListNode* head, int k){
    struct ListNode *faster = head;
    struct ListNode *slower = head;
    for(int i = 0; i < k; i++)
    {
        faster = faster->next;
    }

    while(faster != NULL)
    {
        faster = faster->next;
        slower = slower->next;
    }

    return slower->val;
}
```

*要寻找单链表中的倒数第K项*

*快指针先指向第K项*

*然后快慢指针同时遍历*

*直至快指针为空*

***二、换位***

```c
int result=0;
while(x)
{
    result=result*10+x%10;   
    x/=10;
}
```


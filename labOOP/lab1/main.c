#include <stdio.h>
#include <stdbool.h>
#include <stdlib.h>
#include <string.h>
#include <limits.h>

const int MAX_PRIORITY = 999;


////////////////////STRUCTS//////////////////
typedef struct node
{
    int value;
    int priority;
    struct node *next;
} node;

typedef struct queue
{
    struct node *head, *tail;
} queue;




/////////////////////NEW NODE/////////////////////////
node *createNode(int value)
{
    node *temp = (node *)malloc(sizeof(node));
    temp->value = value;
    temp->next = NULL;
    return temp;
}


/////////////////////NEW QUEUE////////////////////////
queue *initQueue()
{
    queue *q = (queue *)malloc(sizeof(queue));
    q->head = NULL;
    q->tail = NULL;
    return q;
}




bool enQueue(queue *q, int value)
{
    node *temp = createNode(value);
    temp->priority = MAX_PRIORITY;
    // if malloc failed
    if (temp == NULL)
        return false;

    // if queue empty, the new node is both tail and head
    if (q->tail == NULL)
    {
        q->head = q->tail = temp;
        return true;
    }

    // set temp as the next node after tail of the queue
    q->tail->next = temp;
    q->tail = temp;
    return true;
}



void deQueue(queue *q)
{
    // check for empty queue
    if (q->tail == NULL)
        return;

    // new head of the queue
    q->head = q->head->next;
    if (q->head == NULL)
        q->tail = NULL;
}



bool search(queue *q, int value)
{
    queue *temp = q;

    // while queue not empty, compare the value
    // of the head with the value to search
    while (temp->tail != NULL)
    {
        if (temp->head->value == value)
        {
            return true;
        }
        else
            deQueue(temp);
    }

    return false;
}




//////////////////////////PRIORITY QUEUE/////////////////////////////
void pEnqueue(queue *q, int value, int priority)
{
    node *temp = createNode(value);
    temp->next = NULL;

    // if the given priority is too high
    if (priority > MAX_PRIORITY)
    {
        priority = MAX_PRIORITY;
    }

    temp->priority = priority;

    // if q not empty
    if ((q->head != NULL) && (q->tail != NULL))
    {

        // if new node's priority is better than queue's head
        // make new node the head of queue
        if (temp->priority > q->head->priority)
        {
            temp->next = q->head;
            q->head = temp;
        }

        else
        {
            node *prevTemp = q->head;
            node *currentTemp = q->head->next;
            while (currentTemp != NULL && currentTemp->priority < temp->priority)
            {
                prevTemp = currentTemp;
                currentTemp = currentTemp->next;
            }

            if (currentTemp == NULL)
            {
                prevTemp->next = temp;
                q->tail = temp;
            }
            else
            {
                temp->next = currentTemp;
                prevTemp->next = temp;
            }
        }
    }

    else
    {
        q->head = temp;
        q->tail = temp;
    }

}




///////////////STACK FOR THE REVERSE FUNCTION///////////////
node* top = NULL;

void push(int value) {
    struct node *newNode = createNode(value);
    if (top == NULL) {
        newNode->next = NULL;
    } else {
        //Make the node as top
        newNode->next = top;
    }
    //top always points to the newly created node
    top = newNode;
}

int pop() {
    if (top == NULL) {
        printf("\nStack Underflow\n");
    } else {
        struct node *temp = top;
        int temp_data = top->value;
        top = top->next;
        free(temp);
        return temp_data;
    }
}

////////////////////////////////////////////////////////////



void reverseQ(queue *q){
    while((q->head != NULL) && (q->tail != NULL)){
        push(q->head->value);
        deQueue(q);
    }
    while(top!=NULL){
        enQueue(q, top->value);
        pop();
    }
}




int qSize(queue *q){
    int k=0;
    node *temp = q->head;
    while(temp!=NULL){
        k++;
        temp=temp->next;
    }
    return k;
}


//////////////////////////SORTING////////////////////////////
int minIndex(queue *q, int sortedIndex){
    int min_index = -1;
    int min_val = INT_MAX;
    int n = qSize(q);

    for(int i=0; i<n; i++){
        int curr = q->head->value;
        deQueue(q);
        if (curr <= min_val && i <= sortedIndex)
        {
            min_index = i;
            min_val = curr;
        }
        enQueue(q, curr);
    }
    return min_index;
}

void insertMinToTail(queue *q, int min_index){
    int min_val;
    int n = qSize(q);
    for (int i = 0; i < n; i++)
    {
        int curr = q->head->value;
        deQueue(q);
        if (i != min_index)
            enQueue(q, curr);
        else
            min_val = curr;
    }
    enQueue(q, min_val);
}

void sortQ(queue *q){
    int n = qSize(q);
    for (int i = 1; i <= n; i++)
    {
        int min_index = minIndex(q, n - i);
        insertMinToTail(q, min_index);
    }
}





////////////////////////CIRCULAR QUEUE///////////////////////
void circularEnQueue(queue *q, int value){
    node *temp = createNode(value);

    if(q->head == NULL){ q->head = temp; }
    else{ q->tail->next = temp; }

    q->tail = temp;
    q->tail->next = q->head;

}

void circulatDeQueue(queue *q){
    if (q->head != NULL) {
        // If this is the last node to be deleted
        int value;
        if (q->head == q->tail) {
            value = q->head->value;
            free(q->head);
            q->head = NULL;
            q->tail = NULL;
        }
        // There are more than one nodes
        else
        {
            node *temp = q->head;
            value = temp->value;
            q->head = q->head->next;
            q->tail->next = q->head;
            free(temp);
        }
    }
}





void printQ(queue *q){
    node *temp = q->head;
    while (temp!=NULL){
        printf("%d ", temp->value);
        temp=temp->next;
    }
}




int main()
{
    queue *q = initQueue();
    queue *cirQ = initQueue();

    char *message = "Choose an option on queue:\n\
    '1' - add element to queue (enqueue)\n\
    '2' - delete element from queue (dequeue)\n\
    '3' - search element in queue\n\
    '4' - sort queue\n\
    '5' - reverse queue\n\
    '6' - add elements in queue with priority (priority queue)\n\
    '7' - add element to circular queue\n\
    '8' - delete element from circular queue\n\
    'r' - read queue elements from a file\n\
    'w' - write queue in a file\n\
    'e' - exit\n";

    printf("%s", message);
    printf("Option: ");

    char choice;

    while(choice = getchar()){
        
        switch (choice)
        {
        case '1':
            int value;
            printf("Value to add in queue: ");
            scanf("%d", &value);
            enQueue(q, value);
            printf("Queue: ");
            printQ(q);
            printf("\nOption: ");
            break;
        
        case '2':
            deQueue(q);
            printf("Queue: ");
            printQ(q);
            printf("\nOption: ");
            break;

        case '3':
            int value2;
            printf("Value to search: ");
            scanf("%d", &value2);
            if(search(q, value2)){ printf("\nValue is in the queue.\n"); }
            else { printf("Value is not in the queue.\n"); }
            printf("\nOption: ");
            break;

        case '4':
            sortQ(q);
            printf("Queue: ");
            printQ(q);
            printf("\nOption: ");
            break;

        case '5':
            reverseQ(q);
            printf("Queue: ");
            printQ(q);
            printf("\nOption: ");
            break;

        case '6':
            int value3, value4;
            printf("Value to add: ");
            scanf("%d", &value3);
            printf("\nPriority of the value: ");
            scanf("%d", &value4);
            pEnqueue(q, value3, value4);
            printf("\nQueue: ");
            printQ(q);
            printf("\nOption: ");
            break;

        case '7':
            int value5;
            printf("Value to add: ");
            scanf("%d", &value5);
            circularEnQueue(cirQ, value5);
            printf("The value is added to circular queue.\n");
            printf("Option: ");
            break;

        case '8':
            circulatDeQueue(cirQ);
            printf("The value is deleted from circular queue.\n");
            printf("Option: ");
            break;

        case 'r':
            FILE *fptRead;
            char help[256];
            char *c;
            char path[100];
            printf("Path to the file: ");
            scanf("%s", path); 
            fptRead = fopen(path, "r");
            fscanf(fptRead, "%s", help);
            c = strtok(help, ",");
            int i = 0;
            while(c != NULL){
                enQueue(q, atoi(c));
                c = strtok(NULL, ",");
                i++;
            }
            fclose(fptRead);
            printf("Queue: ");
            printQ(q);
            printf("\nOption: ");
            break;

        case 'w':
            FILE *fptWrite;
            char path2[100];
            printf("Name of the file: ");
            scanf("%s", path2); 
            fptWrite = fopen(path2, "a");
            node *temp = q->head;
            while(temp != NULL){
                fprintf(fptWrite, "%d ", temp->value);
                temp = temp->next;
            }
            fclose(fptWrite);
            printf("The queue is written in the file.");
            printf("\nOption: ");
            break;

        case 'e':
            exit(0);

        default:
            break;
        }
    }

    

    return 0;
}
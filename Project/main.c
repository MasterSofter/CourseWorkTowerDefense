#include "mylib.h"
#include <stdio.h>
#include <string.h>


int compare (void* _str1, void* _str2)
{
    char* str1 = (char*)_str1;
    char* str2 = (char*)_str2;

    size_t len = strlen(str1);

    char buff1[len];
    char buff2[len];

    return strcmp(toLowString(buff1, str1), toLowString(buff2, str2));
}

void process(FILE* file, FILE* fout, MyList* myList)
{
    char buff[STR_LEN];
    if(fgets(buff, STR_LEN, file) == NULL)
    {
        if(ftell(file) == 0)
        {
            printf("������� ���� ����");
            return;
        }
            //�����, �� ������ �� ����� �������, ���� ���� ftell ����������� ��������!
        else
        {
            perror("������ ��� ������ � ������ ������!");
            return;
        }

    }

    do{
        //����� ���� �������� �����
        findWordsByLen(myList, buff);
    }while (fgets(buff, STR_LEN, file) != NULL);

    if(ferror(file))
    {
        perror("������ ������ �� �����!");
        return;
    }


    qsort(myList->data, myList->countWords, myList->wordlen + 1, compare);

    for(int i = 0; i < myList->countWords; i ++)
    {
        fwrite(myList->data + i * (myList->wordlen + 1), myList->wordlen , 1, fout);
        if(ferror(fout))
        {
            perror("������ ������ � �������� ����!");
            return;
        }

        fputc('\n',fout);
    }
}

const unsigned char MAX_LEN_WORD = 55;

int main (int argc, char** argv) {
    if(argc < 3)
    {
        printf("\n������! �� ������� ���-�� ������������ ���������� � ���������! �������� ������ �������������� ��������� �������:\n"
               "** ������ �������� - ������� ����\n"
               "** ������ �������� - �������� ����\n"
               "** ������ �������� - ����� ������� ���� (����. ����� ���������� �������� �����: 55 ����)\n ");
        return -1;
    }

    if(strcmp(argv[1], argv[2]) == 0)
    {
        printf("\n������! ���� � ��� ��������� ����� �� ������ ��������� � ������� ������!");
        return -2;
    }
    if(atoi(argv[3]) > MAX_LEN_WORD)
    {
        printf("\n������! ����� ��������� ����� �� � �������, �� � ���������� ����� �� ����������! ������������ ����� ����� - 55");
        return -3;
    }

    if(atoi(argv[3]) <= 0)
    {
        printf("\n������! ����� �������� ����� ������ ���� �������������!");
        return -4;
    }

    FILE* file = NULL;
    FILE* fout = NULL;
    MyList myList;

    int wordlen = atoi(argv[3]);
    int error = 0;

    const char* fName = argv[1];
    const char* fOutName = argv[2];

    unsigned short listCapacity = 10; // ����������� ������
    //�������� � ������������� ������
    if((error = listInit(&myList, listCapacity, wordlen)) != 0)
    {
        printf("������ ��������� ������");
        return error;
    }

    //�������� ����� �� ������
    if((file = fopen(fName, "r")) == NULL)
    {
        perror("������, ���� ��� ������ �� ������!");
        listClear(&myList);
        return -1;
    }

    if((fout = fopen(fOutName, "w")) == NULL)
    {
        perror("������, �� ������� ������� ���� �� ������!");
        fclose(file);
        listClear(&myList);
        return -4;
    }

    process(file, fout, &myList);

    //�������� ������
    fclose(fout);
    fclose(file);

    //������� ������, ������������� ������
    listClear(&myList);

    return 0;
}

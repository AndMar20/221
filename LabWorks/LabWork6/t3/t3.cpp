#include <iostream>
using namespace std;
int main()
{
    setlocale(0, "");
    char string1[] = "Hello world";
    char string2[10];
    int i = 0;
    int n = 2;
    _asm {
        lea esi, string1
        lea edi, string2
        add esi, i
        mov ecx, n
        rep movsb
        mov byte ptr [edi], 0
    }
    cout << string2;
}

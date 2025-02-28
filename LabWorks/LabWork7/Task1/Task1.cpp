#include <iostream>
#include <Windows.h>

extern "C" int SumNumber(int, int);
extern "C" int Double(int);
extern "C" int Compare(void);

int main()
{
    std::cout << SumNumber(2, 4) <<"\n";
    std::cout << Double(4);
    Compare();

}


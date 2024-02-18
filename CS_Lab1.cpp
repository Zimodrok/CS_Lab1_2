#include <vector>
#include <string>
#include <iostream>
#include <conio.h>

int main()
{
    std::cout << "Please drop files and press [Enter] when done ...\n";

    std::vector< std::string > files;

    for (int ch = _getch(); ch != '\r'; ch = _getch()) {

        std::string file_name;

        if (ch == '\"') {  // path containing spaces. read til next '"' ...

            while ((ch = _getch()) != '\"')
                file_name += ch;

        }
        else { // path not containing spaces. read as long as chars are coming rapidly.

            file_name += ch;

            while (_kbhit())
                file_name += _getch();
        }

        files.push_back(file_name);
    }

    std::cout << "You dropped these files:\n";

    for (auto& i : files)
        std::cout << i << '\n';
}
/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#include "client.h"
#include <iostream>
using namespace std;

ClientSocket::ClientSocket()
{
    cout << "Client Default construct!\n";
}

ClientSocket::ClientSocket(int&& fd)
{
    cout << "Client Move construct!\n";
    _fd = move(fd);
}

ClientSocket::~ClientSocket()
{
    cout << "Client Destruct!\n";
}


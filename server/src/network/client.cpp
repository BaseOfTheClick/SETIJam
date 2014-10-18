/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#include "client.h"
using namespace std;

ClientSocket::ClientSocket() = default;

ClientSocket::ClientSocket(int&& fd)
{
    _fd = move(fd);
}

ClientSocket::~ClientSocket()
{
    this->close();
}


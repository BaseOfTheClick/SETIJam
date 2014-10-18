/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#include "tcp.h"
#include <sys/socket.h>
#include <sys/types.h>
#include <unistd.h>
#include <utility>
using namespace std;

Buffer::Buffer() : _buffer(nullptr)
{
}

Buffer::Buffer(int bufferSize)
    : _buffer(new char[bufferSize])
{
}

Buffer::~Buffer()
{
    if(_buffer)
        delete [] _buffer;
}

Socket::Socket() : _fd(0)
{
    // Default constructor
}

Socket::Socket(int inet, int type, int prot)
{
    this->close();
    _fd = socket(inet, type, prot);
}

Socket::~Socket()
{
    this->close();
}

Socket::operator bool()
{
    return _fd > 0;
}

Socket::operator int&()
{
    return _fd;
}

Socket& Socket::operator=(int&& fd)
{
    _fd = move(fd);
    return *this;
}

void Socket::setSockOpt(int opt, int on)
{
    int optval = on;
    setsockopt(_fd, SOL_SOCKET, opt, &optval, sizeof(int));
}

Socket& Socket::close()
{
    if(_fd > 0)
        ::close(_fd);
    return *this;
}




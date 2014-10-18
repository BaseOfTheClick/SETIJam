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

Socket::Socket(const Socket& other) : _fd(other._fd)
{
    // Copy constructor
}

Socket::Socket(Socket&& other) : _fd(move(other._fd))
{
    // Move constructor
}

Socket::~Socket()
{
    this->close();
}

int Socket::accept(int backlog)
{
    return 0;
}

int Socket::listen()
{
    return 0;
}

int Socket::connect(const char *host, const char *port)
{
    return 0;
}

void Socket::close()
{
    if(_fd > 0)
        ::close(_fd);
}


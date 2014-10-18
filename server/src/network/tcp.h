/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#ifndef TCP_H
#define TCP_H

#include "address.h"
#include <fcntl.h>

class Buffer
{
    char *_buffer;

public:
    Buffer();
    Buffer(int bufferSize);
    ~Buffer();

};

class Socket
{
protected:
    int _fd {0};

public:
    Socket();
    Socket(int inet, int type, int prot);
    ~Socket();

    explicit operator bool();
    operator int&();

    Socket& operator=(int&& fd);

    void setSockOpt(int opt);

    Socket& close();
};

#endif /* TCP_H */



/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#ifndef CLIENT_H
#define CLIENT_H

#include "tcp.h"

class ClientSocket : public Socket
{
public:
    ClientSocket();
    ClientSocket(int&& fd);
    ~ClientSocket();
};

struct Client
{
    ClientAddress addr;
    ClientSocket sock;
};

#endif /* CLIENT_H */




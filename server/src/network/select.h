/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#ifndef SELECT_H
#define SELECT_H

#include "tcp.h"
#include <sys/select.h>
#include <vector>

class Multiplexer
{
    std::vector<Socket *> sockets;
    int max;
    int current;
    fd_set afds, wfds, rfds;

public:
    Multiplexer();
    bool insert(Socket *sock);

    int poll();
    Socket* next();
    bool setWrite(Socket *sock);
    bool setRead(Socket *sock);

};

#endif /* SELECT_H */


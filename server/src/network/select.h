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
    fd_set afds, wfds, rfds;

public:
    Multiplexer();
    bool insert(Socket *sock);
    void eradicate(int s);

    int poll();
    bool setWrite(int sock);
    bool setRead(int sock);

};

#endif /* SELECT_H */

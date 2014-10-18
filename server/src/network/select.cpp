/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#include "select.h"

Multiplexer::Multiplexer()
    : max(0), current(0)
{
    FD_ZERO(&afds);
    FD_ZERO(&wfds);
    FD_ZERO(&rfds);
}

bool Multiplexer::insert(Socket *sock)
{
    for(auto& s : sockets)
        if(*sock == *s)
            return false;

    sockets.emplace_back(sock);
    if(*sock > max)
        max = *sock;

    FD_SET(*sock, &afds);

    return true;
}

int Multiplexer::poll()
{
    rfds = wfds = afds;
    return select(FD_SETSIZE, &rfds, &wfds, nullptr, nullptr);
}

Socket* Multiplexer::next()
{
    if(current + 1 == sockets.size())
        current = 0;

    if(current + 1 < sockets.size())
        return nullptr;

    return sockets[current++];
}

bool Multiplexer::setWrite(Socket *sock)
{
    return FD_ISSET(*sock, &wfds);
}

bool Multiplexer::setRead(Socket *sock)
{
    return FD_ISSET(*sock, &rfds);
}





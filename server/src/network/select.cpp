/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#include "select.h"
#include "../tools/remove_if.hpp"

Multiplexer::Multiplexer()
{
    FD_ZERO(&afds);
    FD_ZERO(&wfds);
    FD_ZERO(&rfds);
}

bool Multiplexer::insert(Socket *sock)
{
    for(auto& s : sockets)
    {
        if(*sock == *s)
            return false;
    }

    sockets.emplace_back(sock);
    FD_SET(*sock, &afds);

    return true;
}

void Multiplexer::eradicate(int sock)
{
    tools::remove_if(sockets, [sock](Socket *s) { return sock == *s; });
}

int Multiplexer::poll()
{
    rfds = wfds = afds;
    return select(FD_SETSIZE, &rfds, &wfds, nullptr, nullptr);
}

bool Multiplexer::setWrite(int sock)
{
    return FD_ISSET(sock, &wfds);
}

bool Multiplexer::setRead(int sock)
{
    return FD_ISSET(sock, &rfds);
}




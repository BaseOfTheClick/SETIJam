/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: server.h
 * Address Module for this [server] aspect of multiplayer at SETI-Jam */
#ifndef SERVER_H
#define SERVER_H

#include "tcp.h"
#include "client.h"
#include <utility>

class ServerSocket : public Socket
{
    std::vector<std::pair<ClientSocket, ClientAddress>> clients;

public:
    ServerSocket();
    ServerSocket(Address& addr);
    ~ServerSocket();

    ServerSocket& bind(Address& addr);
    ServerSocket& listen(int backlog);
    ServerSocket& accept();

};

#endif /* SERVER_H */


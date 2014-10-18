/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#ifndef TCP_H
#define TCP_H

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
    int _fd {0};

public:
    Socket();
    Socket(int inet, int type, int prot);
    Socket(const Socket& other);
    Socket(Socket&& other);
    ~Socket();

    int accept(int backlog);
    int listen();
    int connect(const char *host, const char *port);
    void close();
};

#endif /* TCP_H */


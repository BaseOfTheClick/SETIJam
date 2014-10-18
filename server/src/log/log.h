/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#ifndef LOG_H
#define LOG_H

#include <ctime>
#include <fstream>

class LogFile
{
    std::ofstream _ofs;
    char *_time;
    struct tm *_timeinfo;
    time_t _rawtime;

public:
    LogFile();
    ~LogFile();

private:
    void getCurrentTime();

};

#endif /* LOG_H */


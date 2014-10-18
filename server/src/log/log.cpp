/* Authors: Kevin Morris, Gani Parrott, Jesse Hamburger
 * File: main.cpp
 * TCP Module for this [server] aspect of multiplayer at SETI-Jam */
#include "log.h"

LogFile::LogFile() : _time(new char[20])
{
}

LogFile::~LogFile()
{
    if(_ofs.is_open())
        _ofs.close();

    delete [] _time;
}

void LogFile::getCurrentTime()
{
    time(&_rawtime);
    _timeinfo = localtime(&_rawtime);
    strftime(_time, 20, "[%D %T]", _timeinfo);
}


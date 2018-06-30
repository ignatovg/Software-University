using System;
using System.Collections.Generic;
using System.Text;

namespace P04_OnlineRadioDatabase
{
    //class Exceptions
    //{
    //}

    class InvalidSongException:Exception
    {
        public override string Message => "Invalid song.";
    }

    class InvalidArtistNameException:Exception
    {
        public override string Message => "Artist name should be between 3 and 20 symbols.";
    }

    class InvalidSongNameException:Exception
    {
        public override string Message => "Song name should be between 3 and 30 symbols.";
    }

    class InvalidSongLengthException:Exception
    {
        public override string Message => "Invalid song length.";
    }

    class InvalidSongMinutesException:Exception
    {
        public override string Message => "Song minutes should be between 0 and 14.";
    }

    class InvalidSongSecondsException:Exception
    {
        public override string Message => "Song seconds should be between 0 and 59.";
    }
}

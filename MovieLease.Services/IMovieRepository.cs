using MovieLease.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLease.Services
{
    public interface IMovieRepository
    {
        //movies
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int MovieId);
        //users
        User Add(User newUser);
        //User GetByName(string UserName);
        string UserExist(string UserName, string Password);
        User GetUserByName(string UserName);

        //records
        bool AddRecord(Record Record);
        Record GetRecordById(int RecordId);
        IEnumerable<Record> GetRecordByUser(string UserName);
        IEnumerable<Record> GetDefaulters();
        IEnumerable<Record> GetReturnedRecords();


        Record UpdateRecordById(int RecordId);
        //general
        int Commit();
       

    }
}

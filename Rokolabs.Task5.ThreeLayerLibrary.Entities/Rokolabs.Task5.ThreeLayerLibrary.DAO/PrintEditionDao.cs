using Rokolabs.Task5.ThreeLayerLibrary.DAL.Interfaces;
using Rokolabs.Task5.ThreeLayerLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rokolabs.Task5.ThreeLayerLibrary.DAO
{
    public class PrintEditionDao : BaseDao, IPrintEditionDao
    {
        public void ContentReader(SqlDataReader reader, ref List<PrintEdition> printEditions)
        {
            switch (reader["Type"])
            {
                case BookCaseType:
                    printEditions.Add(new Book()
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"] as string,
                        Annotation = reader["Annotation"] as string,
                        PublicationYear = (int)reader["PublicationYear"],
                        ISBN = reader["BookISBN"] as string,
                        PublishingHouse = reader["BookPublishingHouse"] as string,
                        PlaceOfPublication = reader["BookPlaceOfPublication"] as string,
                        NumberOfPages = (int)reader["BookNumberOfPages"]
                    });
                    break;

                case PatentCaseType:
                    printEditions.Add(new Patent()
                    {
                        Id = (int)reader["Id"],
                        Country = reader["PatentCountry"] as string,
                        RegistrationNumber = (int)reader["PatentRegistrationNumber"],
                        DateOfApplication = (DateTime)reader["PatentDateOfApplication"],
                        Title = reader["Title"] as string,
                        PublicationYear = (int)reader["PublicationYear"],
                        NumberOfPages = (int)reader["PatentNumberOfPages"],
                        PublicationDate = (DateTime)reader["PatentPublicationDate"],
                        Annotation = reader["Annotation"] as string
                    });
                    break;

                case NewspaperCaseType:
                    printEditions.Add(new Newspaper()
                    {
                        Id = (int)reader["Id"],
                        PublicationYear = (int)reader["PublicationYear"],
                        Title = reader["Title"] as string,
                        Annotation = reader["Annotation"] as string,
                        ISSN = reader["NewspaperISSN"] as string,
                        PlaceOfPublication = reader["NewspaperPlaceOfPublication"] as string,
                        PublishingHouse = reader["NewspaperPublishingHouse"] as string
                    });

                    break;
            }
        }

        public void GetAuthorsId(ref List<PrintEdition> printEditions)
        {
            AuthorDao authorDao = new AuthorDao();
            foreach (var item in printEditions)
            {
                if (item is Book)
                {
                    Book working = (Book)item;
                    working.AuthorsId = authorDao.GetAuthorsIdsByBookId(item.Id);
                }
                if (item is Patent)
                {
                    Patent working = (Patent)item;
                    working.AuthorsId = authorDao.GetAuthorsIdsByPatentId(item.Id);
                }
            }
        }

        public IEnumerable<PrintEdition> GetAllPrintEditions()
        {
            List<PrintEdition> printEditions = new List<PrintEdition>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "GetAllPrintEditions");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ContentReader(reader, ref printEditions);
                }
            }
            GetAuthorsId(ref printEditions);
            return printEditions;
        }

        public IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYear()
        {
            List<PrintEdition> printEditions = new List<PrintEdition>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "GetAllPrintEditionsSortedByPublicationYear");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ContentReader(reader, ref printEditions);
                }
            }
            GetAuthorsId(ref printEditions);
            return printEditions;
        }

        public IEnumerable<PrintEdition> GetAllPrintEditionsSortedByPublicationYearDescending()
        {
            List<PrintEdition> printEditions = new List<PrintEdition>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "GetAllPrintEditionsSortedByPublicatoinYearDescending");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ContentReader(reader, ref printEditions);
                }
            }
            GetAuthorsId(ref printEditions);
            return printEditions;
        }

        public PageResult<PrintEdition> SortedPaging(PageOption pageOption, string partAuthorName, string sortString, string partTitle)
        {
            List<PrintEdition> printEditions = new List<PrintEdition>();
            int totalCount = 0;
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "dbo.GetPagesByFilterParameters");
                command.Parameters.AddWithValue("@skip", pageOption.Skip);
                command.Parameters.AddWithValue("@limit", pageOption.Limit);
                command.Parameters.AddWithValue("@partAuthorName", partAuthorName);
                command.Parameters.AddWithValue("@sortString", sortString);
                command.Parameters.AddWithValue("@partTitle", partTitle);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ContentReader(reader, ref printEditions);
                    }

                    reader.NextResult();

                    if (reader.Read())
                    {
                        totalCount = (int)reader["TotalCount"];
                    }
                }
            }
            GetAuthorsId(ref printEditions);
            return new PageResult<PrintEdition>()
            {
                Data = printEditions,
                TotalCount = totalCount,
                _partAuthorName = partAuthorName,
                _partTitle = partTitle,
                _sortString = sortString
            };
        }

        public IEnumerable<PrintEdition> DownloadTheCatalog()
        {
            List<PrintEdition> printEditions = new List<PrintEdition>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = GetCommand(connection, "GetAllCatalogForDownloading");
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    switch (reader["Type"])
                    {
                        case BookCaseType:
                            printEditions.Add(new Book()
                            {
                                Id = (int)reader["Id"],
                                Title = reader["Title"] as string,
                                Annotation = reader["Annotation"] as string,
                                PublicationYear = (int)reader["PublicationYear"],
                                ISBN = reader["BookISBN"] as string,
                                PublishingHouse = reader["BookPublishingHouse"] as string,
                                PlaceOfPublication = reader["BookPlaceOfPublication"] as string,
                                NumberOfPages = (int)reader["BookNumberOfPages"]
                            });
                            break;

                        case PatentCaseType:
                            printEditions.Add(new Patent()
                            {
                                Id = (int)reader["Id"],
                                Country = reader["PatentCountry"] as string,
                                RegistrationNumber = (int)reader["PatentRegistrationNumber"],
                                DateOfApplication = (DateTime)reader["PatentDateOfApplication"],
                                Title = reader["Title"] as string,
                                PublicationYear = (int)reader["PublicationYear"],
                                NumberOfPages = (int)reader["PatentNumberOfPages"],
                                PublicationDate = (DateTime)reader["PatentPublicationDate"],
                                Annotation = reader["Annotation"] as string
                            });
                            break;

                        case NewspaperCaseType:
                            printEditions.Add(new Newspaper()
                            {
                                Id = (int)reader["Id"],
                                PublicationYear = (int)reader["PublicationYear"],
                                Title = reader["Title"] as string,
                                Annotation = reader["Annotation"] as string,
                                ISSN = reader["NewspaperISSN"] as string,
                                PlaceOfPublication = reader["NewspaperPlaceOfPublication"] as string,
                                PublishingHouse = reader["NewspaperPublishingHouse"] as string,

                                currentNewspaperIssue = new NewspaperIssue()
                                {
                                    NewspaperId = (int)reader["NewspaperIssueNewspaperId"],
                                    ReleaseDate = (DateTime)reader["NewspaperIssueReleaseDate"],
                                    ReleaseNumber = (int)reader["NewspaperIssueReleaseNumber"],
                                    NumberOfPages = (int)reader["NewspaperIssueNumberOfPages"]
                                }
                            });

                            break;
                    }
                }
            }
            return printEditions;
        }
    }
}
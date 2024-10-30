namespace user_microservice.Src.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Gets the subjects repository.
        /// </summary>
        /// <value>A Concrete class for ISubjectsRepository</value>
        public ISubjectsRepository SubjectsRepository { get; }
        public ISubjectRelationshipsRepository SubjectRelationshipsRepository { get; }

    }
}
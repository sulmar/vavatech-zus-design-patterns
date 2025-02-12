namespace BuilderPattern
{
    public interface IFrom
    {
        ITo From(string from);
    }

    public interface ITo
    {
        IToOrSubjectOrCall To(string to);
    }

    public interface ISubject
    {
        ICall WithSubject(string subject);
    }

    public interface ICall
    {
        Call Build();
    }

    public interface IToOrSubjectOrCall : ITo, ISubject, ICall
    {

    }

    public class CallBuilder : IFrom, ITo, ISubject, IToOrSubjectOrCall, ICall
    {
        private Call call = new Call();

        public ITo From(string from)
        {
            call.From = from;

            return this;
        }

        public IToOrSubjectOrCall To(string to)
        {
            call.To.Add(to);

            return this;
        }

        public ICall WithSubject(string subject)
        {
            call.Subject = subject;

            return this;
        }

        public Call Build()
        {
            return call;
        }
    }


}
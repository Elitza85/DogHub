namespace DogHub.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Result
    {
        private readonly List<string> errors;

        internal Result(bool succeeded, List<string> errors)
        {
            this.Succeeded = succeeded;
            this.errors = errors;
        }

        public bool Succeeded { get; }

        public List<string> Errors
            => this.Succeeded
                ? new List<string>()
                : this.errors;

        public static Result Success
            => new Result(true, new List<string>());

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, errors.ToList());
        }

        public static implicit operator Result(string error)
        {
            return Failure(new List<string> { error });
        }

        public static implicit operator Result(List<string> errors)
        {
            return Failure(errors.ToList());
        }

        public static implicit operator Result(bool success)
        {
            return success ? Success : Failure(new[] { "Unsuccessful operation." });
        }

        public static implicit operator bool(Result result)
        {
            return result.Succeeded;
        }
    }

    public class Result<TData> : Result
    {
        private readonly TData data;

        private Result(bool succeeded, TData data, List<string> errors)
            : base(succeeded, errors)
        {
            this.data = data;
        }

        public TData Data()
        {
            return this.Succeeded
                ? this.data
                : throw new InvalidOperationException(
                    $"{nameof(this.Data)} is not available with failed result. Use {this.Errors} instead.");
        }

        public static Result<TData> SuccessWith(TData data)
        {
            return new Result<TData>(true, data, new List<string>());
        }

        public new static Result<TData> Failure(IEnumerable<string> errors)
        {
            return new Result<TData>(false, default!, errors.ToList());
        }

        public static implicit operator Result<TData>(string error)
        {
            return Failure(new List<string> { error });
        }

        public static implicit operator Result<TData>(List<string> errors)
        {
            return Failure(errors);
        }

        public static implicit operator Result<TData>(TData data)
        {
            return SuccessWith(data);
        }

        public static implicit operator bool(Result<TData> result)
        {
            return result.Succeeded;
        }
    }
}

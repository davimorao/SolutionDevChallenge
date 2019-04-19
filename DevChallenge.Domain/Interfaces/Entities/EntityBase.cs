using System;
using FluentValidation;
using FluentValidation.Results;

namespace DevChallenge.Domain.Interfaces.Entities
{
    public abstract class EntityBase<T> : AbstractValidator<T> where T : EntityBase<T>
    {
        #region Properties

        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? IdUsuarioCadastro { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public bool Status { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        #endregion

        #region Methods

        public abstract bool IsValid();

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityBase<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907 + Id.GetHashCode());
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + "]";
        }

        #endregion

        #region Operators

        public static bool operator ==(EntityBase<T> a, EntityBase<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityBase<T> a, EntityBase<T> b)
        {
            return !(a == b);
        }

        #endregion
    }
}

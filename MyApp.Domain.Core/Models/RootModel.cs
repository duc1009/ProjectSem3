using System;

namespace MyApp.Domain.Core.Models
{
    /// <summary>
    /// Lớp cơ sở của các lớp dữ liệu
    /// </summary>
    public class RootModel : Entity
    {
        #region Protected Constructors

        protected RootModel()
        {
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
        }

        protected RootModel(Guid id) : base(id)
        {
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
        }

        protected RootModel(Guid id, string createdBy) : this(id)
        {
            CreatedBy = createdBy;
            ModifiedBy = createdBy;
        }
        protected RootModel(Guid id, int portal, string createdBy) : this(id)
        {
            PortalId = portal;
            CreatedBy = createdBy;
            ModifiedBy = createdBy;
        }

        #endregion Protected Constructors

        #region Public Properties

        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Có xóa hay không
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }

        public int PortalId { get; set; }
        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        public void Delete(string updatedBy = null)
        {
            IsDeleted = true;
            if (!string.IsNullOrEmpty(updatedBy)) ModifiedBy = updatedBy;
            Modified = DateTime.UtcNow;
        }

        /// <summary>
        /// Khởi tạo
        /// </summary>
        public void Intialize()
        {
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
        }

        /// <summary>
        /// Cập nhật dữ liệu
        /// </summary>
        /// <param name="modifiedBy"></param>
        public void Update(string modifiedBy = null)
        {
            ModifiedBy = modifiedBy;
            Modified = DateTime.UtcNow;
        }

        #endregion Public Methods
    }
}
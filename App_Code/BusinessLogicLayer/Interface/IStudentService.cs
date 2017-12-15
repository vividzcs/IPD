using Models;

/**
 * 
 */
namespace BusinessLogicLayer.Interface
{
    public interface IStudentService : IBusinessLogicLayerBase {


        /// <summary>
        /// ��¼
        /// </summary>
        /// <param name="student">Ҫ��¼��ѧ������</param>
        /// <returns>ȫ����װ��������������ѧ������</returns>
        Student Login(Student student);

        /// <summary>
        /// �޸�ѧ������
        /// </summary>
        /// <param name="student">Ҫ�޸ĵ�ѧ�����ĺ�������Ѿ�����</param>
        /// <returns>1�ɹ� 0ʧ��</returns>
        int ModifyPassword(Student student);

    }
}
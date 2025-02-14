using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private float startPos = 80;
    private float goalPos = 360;
    private float posRange = 3.4f;//�A�C�e�����o��������
    
    

    // Start is called before the first frame update
    void Start()
    {

        //�X�^�[�g����S�[���܂�z�����i��ʉ������j��15m���X�y�[�X�������ăA�C�e���𐶐�
        for (float i = startPos; i < goalPos; i += 15)
            {
                //��Q���icone�j�𐶐����邩�A�A�C�e���icoin�܂���car�j�𐶐����邩�����߂�
                int num = Random.Range(1, 11);

                //num��2�ȉ��̏ꍇ�i�܂�A20%�̊m���j�A��Q���𐶐�
                if (num <= 2)
                {
                    //x���W��-1����1�܂�0.4���ω������Ȃ���J��Ԃ�
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        //conePrefab�����ɁA��Q���I�u�W�F�N�g�𐶐�
                        GameObject cone = Instantiate(conePrefab);
                        //����������Q���̈ʒu���Ax���W�i���j��4 * j�Az���W�i���j��i�ɐݒ�
                        //z�����i���j�Ɉ��Ԋu�ŕ��сAx�����i���j�ɏ������ʒu�����ꂽ�����̏�Q��������
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    }
                }
                //num��3�ȏ�̏ꍇ�i�܂�A80%�̊m���j�A�A�C�e���𐶐�
                else
                {
                    //x���W(����j��-1����1�܂�1���ω������Ȃ���J��Ԃ�
                    for (int j = -1; j <= 1; j++)
                    {
                        //1����10�܂ł̃����_���Ȑ����𐶐����Aitem�Ɋi�[
                        //���̗����ɂ���āAcoin�𐶐����邩car�𐶐����邩�����܂�
                        int item = Random.Range(1, 11);

                        //z���W�̃I�t�Z�b�g��-5����5�͈̔͂Ń����_���ɐ���
                        int offsetZ = Random.Range(-5, 6);

                        //�����̏����ɂ���āAz�����Ɉ��Ԋu�ŕ��сAx�����ɏ������ʒu�����ꂽ�����̃A�C�e���icoin�܂���car�j�������_���ɐ���
                        //1����6�̏ꍇ�i�܂�A60%�̊m���j�Acoin�𐶐�
                        if (1 <= item && item <= 6)
                        {
                            GameObject coin = Instantiate(coinPrefab);
                            //��������coin�̈ʒu���Ax���W�i���j��posRange * j�Az���W(���j��i + offsetZ�ɐݒ�
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        }

                        //item��7����9�̏ꍇ�i�܂�A30%�̊m���j�Acar�𐶐�
                        else if (7 <= item && item <= 9)
                        {
                            GameObject car = Instantiate(carPrefab);

                            //��������car�̈ʒu���Ax���W��posRange * j�Az���W��i + offsetZ�ɐݒ�
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }


                    }

                }


            }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   


}

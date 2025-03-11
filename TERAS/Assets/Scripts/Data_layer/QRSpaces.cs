using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QRSpaces : MonoBehaviour
{
    public List<QRSpace> qRSpaces = new List<QRSpace>();
    public List<QRSpace> GetQRSpaces()
    { return (qRSpaces); }
    public void SetQRSpace(List<QRSpace> value)
    {
        qRSpaces = value;
    }
    public void AddQRSpace(QRSpace qRSpace)
    { qRSpaces.Add(qRSpace); }
    public void RemoveQRSpace(QRSpace qRSpace)
    { qRSpaces.Remove(qRSpace); }
}

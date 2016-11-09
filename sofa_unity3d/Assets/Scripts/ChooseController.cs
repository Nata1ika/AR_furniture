using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChooseController : MonoBehaviour
{
    [System.Serializable]
    public class Element
    {
        [SerializeField] Button     _button;
        [SerializeField] GameObject _activeImage;
        [SerializeField] GameObject _obj;

        int                 _index;
        ChooseController    _controller;

        public void Activate(ChooseController controller, int index)
        {
            _controller = controller;
            _index = index;
            _button.onClick.AddListener(Click);
        }

        public void Deactivate()
        {
            _button.onClick.RemoveListener(Click);
        }

        void Click()
        {
            _controller.Click(_index);
        }

        public void Show()
        {
            _obj.SetActive(true);
            _activeImage.SetActive(true);
        }

        public void Hide()
        {
            _obj.SetActive(false);
            _activeImage.SetActive(false);
        }
    }
	
    void Start()
    {
        for (int i = 0; i < _element.Length; i++)
        {
            _element[i].Activate(this, i);
        }
        Click(0);
    }

    public void Click(int index)
    {
        if (index == _index)
        {
            return;
        }
        _index = index;
        for (int i = 0; i < _element.Length; i++)
        {
            if (_index == i)
            {
                _element[i].Show();
            }
            else
            {
                _element[i].Hide();
            }
        }
    }

    public void Show()
    {
        _show = !_show;

        for (int i = 0; i < _obj.Length; i++)
        {
            _obj[i].SetActive(_show);
        }
    }

    void OnDestroy()
    {
        for (int i = 0; i < _element.Length; i++)
        {
            _element[i].Deactivate();
        }
    }

    [SerializeField] Element[]      _element;
    [SerializeField] GameObject[]   _obj;

    int _index = -1;
    bool _show = true;
}

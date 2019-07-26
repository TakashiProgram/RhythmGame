using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;

public class InfiniteScroll : UIBehaviour
{
	[SerializeField]
	private RectTransform m_MusicsPrototype;

	[SerializeField, Range(0, 30)]
	private int m_InstantateMusicsCount = 9;

	[SerializeField]
	public Direction m_Direction;

	//public OnItemPositionChange OnUpdateMusics = new OnItemPositionChange();

	[System.NonSerialized]
	public LinkedList<RectTransform> m_MusicsList = new LinkedList<RectTransform>();

	protected float m_DiffPreFramePosition = 0;

	protected int m_CurrentMusicsNo = 0;

	public enum Direction
	{
		Vertical,
		Horizontal,
	}

	// cache component

	private RectTransform _rectTransform;
	protected RectTransform rectTransform {
		get {
			if(_rectTransform == null) _rectTransform = GetComponent<RectTransform>();
			return _rectTransform;
		}
	}

	private float anchoredPosition
	{
		get {
			return m_Direction == Direction.Vertical ? -rectTransform.anchoredPosition.y : rectTransform.anchoredPosition.x;
		}
	}

	private float _itemScale = -1;
	public float itemScale {
		get {
			if(m_MusicsPrototype != null && _itemScale == -1) {
				_itemScale = m_Direction == Direction.Vertical ? m_MusicsPrototype.sizeDelta.y : m_MusicsPrototype.sizeDelta.x;
			}
			return _itemScale;
		}
	}

	protected override void Start ()
	{
		var controllers = GetComponents<MonoBehaviour>()
				.Where(item => item is IInfiniteScrollSetup)
				.Select(item => item as IInfiniteScrollSetup)
				.ToList();

		// create items

		var scrollRect = GetComponentInParent<ScrollRect>();
		scrollRect.horizontal = m_Direction == Direction.Horizontal;
		scrollRect.vertical = m_Direction == Direction.Vertical;
		scrollRect.content = rectTransform;

        m_MusicsPrototype.gameObject.SetActive(false);
		
		for(int i = 0; i < m_InstantateMusicsCount; i++) {
			var item = GameObject.Instantiate(m_MusicsPrototype) as RectTransform;
			item.SetParent(transform, false);
			item.name = i.ToString();
			item.anchoredPosition = m_Direction == Direction.Vertical ? new Vector2(0, -itemScale * i) : new Vector2(itemScale * i, 0);
            m_MusicsList.AddLast(item);

			item.gameObject.SetActive(true);

			foreach(var controller in controllers) {
				controller.OnUpdateItem(i, item.gameObject);
			}
		}

		foreach(var controller in controllers){
			controller.OnPostSetupItems();
		}
	}

	void Update()
	{
		if (m_MusicsList.First == null) {
			return;
		}

		while(anchoredPosition - m_DiffPreFramePosition < -itemScale * 2) {
            m_DiffPreFramePosition -= itemScale;

			var item = m_MusicsList.First.Value;
            m_MusicsList.RemoveFirst();
            m_MusicsList.AddLast(item);

			var pos = itemScale * m_InstantateMusicsCount + itemScale * m_CurrentMusicsNo;
			item.anchoredPosition = (m_Direction == Direction.Vertical) ? new Vector2(0, -pos) : new Vector2(pos, 0);

           // OnUpdateMusics.Invoke(m_CurrentMusicsNo + m_InstantateMusicsCount, item.gameObject);

            m_CurrentMusicsNo++;
		}

		while(anchoredPosition - m_DiffPreFramePosition > 0) {
            m_DiffPreFramePosition += itemScale;

			var item = m_MusicsList.Last.Value;
            m_MusicsList.RemoveLast();
            m_MusicsList.AddFirst(item);

            m_CurrentMusicsNo--;

			var pos = itemScale * m_CurrentMusicsNo;
			item.anchoredPosition = (m_Direction == Direction.Vertical) ? new Vector2(0, -pos): new Vector2(pos, 0);
            //OnUpdateMusics.Invoke(m_CurrentMusicsNo, item.gameObject);
		}
	}

	[System.Serializable]
	public class OnItemPositionChange : UnityEngine.Events.UnityEvent<int, GameObject> {}
}

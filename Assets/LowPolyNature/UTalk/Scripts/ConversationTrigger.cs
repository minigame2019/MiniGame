using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UTalk
{
    public class ConversationTrigger : MonoBehaviour
    {
        public UnityEvent OnConversationStart;

        public UnityEvent OnConversationStop;

        public string ConversationName;

        private bool mIsActive = true;

        public void SetTriggerActive(bool active)
        {
            mIsActive = active;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player" && other is BoxCollider && mIsActive)
            {
                ConversationManager.Instance.StartConversation(ConversationName);

                OnConversationStart.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player" && other is BoxCollider)
            {
                ConversationManager.Instance.StopConversation();

                OnConversationStop.Invoke();
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.Skill;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Main.Scripts.Pickup
{
    public class SRPickup : MonoBehaviour
    {
        [FormerlySerializedAs("skill")] [SerializeField] private SRSkillProperties skillProperties;
        [SerializeField] private Material pickupIconMat;
        [SerializeField] private Collider col;
        [SerializeField] private GameObject destroyFX;
        [SerializeField] private GameObject pickupFXParent;

        private void OnEnable()
        {
            pickupIconMat.mainTexture = SpriteToTextureConverter.TextureFromSprite(skillProperties.SkillIcon);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody == null) return;
            if (!other.attachedRigidbody.TryGetComponent(out CarSkillManager carSkillManager)) return;
            if (!carSkillManager.EquipSkillIfPossible(skillProperties)) return;
            
            Destroy(col);
            pickupFXParent.SetActive(false);
            destroyFX.SetActive(true);
            Instantiate(skillProperties.SkillPrefab, other.attachedRigidbody.transform);
            Destroy(gameObject, .5f);
        }
    }
}
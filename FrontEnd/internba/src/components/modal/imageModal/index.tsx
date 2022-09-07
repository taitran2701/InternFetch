import { useState } from "react";
import styles from "./index.module.scss";

export interface IAddPic {
  show: boolean;
  onClose: () => void;
}
export default function AddPic(props: IAddPic) {
  const { onClose } = props;

  if (!props.show) {
    return null;
  }
  return (
    <div className={styles.modal}>
      <div className={styles.content} onClick={(e) => e.stopPropagation()}>
        <div className={styles.header}>
          <h4 className={styles.title}>Add picture's link</h4>
        </div>
        <div className={styles.body}>
          <input type="text" />
        </div>
        <div className={styles.footer}>
          <div>
            <button> Add</button>
            <button onClick={props.onClose} className={styles.button}>
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

import { useState } from "react";
import { idText } from "typescript";
import styles from "./index.module.scss";

export interface IAddAttach {
  show: boolean;
  onClose: () => void;
  id: string;
}

export default function AddPic(props: IAddAttach) {
  const { onClose, id } = props;
  const [content, setContent] = useState<string>("");

  const addAttach = () => {
    fetch("https://localhost:7076/api/Categories", {
      method: "POST",
      body: JSON.stringify({
        image: content,
        postID: id,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((response) => response.json())
      .then((attach) => {
        setContent(attach);
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  const handleAttach = (e: any) => {
    e.preventDefault();
    addAttach();
    onClose();
  };

  if (!props.show) {
    return null;
  }
  return (
    <div className={styles.modal}>
      <div className={styles.content} onClick={(e) => e.stopPropagation()}>
        <div className={styles.header}>
          <h4 className={styles.title}>Add attach's link</h4>
        </div>
        <div className={styles.body}>
          <input
            value={content}
            type="text"
            onChange={(e) => setContent(e.target.value)}
          />
        </div>
        <div className={styles.footer}>
          <div>
            <button onClick={handleAttach}> Add</button>
            <button onClick={props.onClose} className={styles.button}>
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

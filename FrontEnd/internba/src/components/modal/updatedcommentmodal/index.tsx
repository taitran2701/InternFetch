import React, { useEffect, useState } from "react";
import styles from "./index.module.scss";

export interface IUpdateComment {
  show: boolean;
  onClose: () => void;
  id: string;
  handleComment: any;
}
function UpdateComment(props: IUpdateComment) {
  const { onClose, id, handleComment } = props;
  const [content, setContent] = useState<string>("");

  const updateComment = () => {
    const curId = id;
    fetch(`https://localhost:7076/api/Comments/${curId}`, {
      method: "PUT",
      body: JSON.stringify({
        content: content,
        id: curId,
      }),
      headers: {
        "Content-type": "application/json; charset=UTF-8",
      },
    })
      .then((res) => {
        return res.json();
      })
      .then((comment) => {
        //setContent(comment.content);
        handleComment();
      })
      .catch((err) => {
        console.log(err.message);
      });
  };

  const handleUpdate = (e: any) => {
    updateComment();
    onClose();
  };
  return (
    <div className={styles.modal}>
      <div className={styles.content} onClick={(e) => e.stopPropagation()}>
        <div className={styles.header}>
          <h4 className={styles.title}>Update Comment</h4>
        </div>
        <div className={styles.body}>
          <input
            type="text"
            value={content}
            onChange={(e) => setContent(e.target.value)}
          />
        </div>
        <div className={styles.footer}>
          <div>
            <button onClick={handleUpdate}> Update</button>
            <button onClick={props.onClose} className={styles.button}>
              Cancel
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default UpdateComment;

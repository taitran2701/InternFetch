import modal from "./index.module.scss";
import add from "./addStatusModal.module.scss";

const PostModal = (props: { show: any }) => {
  if (!props.show) {
    return null;
  }
  return (
    <div className={modal.modal}>
      <div className={modal.content}>
        <div className={add.header}>
          <span> Create Post</span>
          <button className={add.closeButton}></button>
        </div>
        <div className={add.body}>
          <div className={add.user}>
            <img
              className={add.avatar}
              src="https://i.pinimg.com/736x/9b/89/2c/9b892c9c099e0c98db5bb9fe5a04d43e.jpg"
              alt=""
            />
            <div className={add.userWrapper}>
              <div className={add.userName}>Tai Tran</div>
              <button>Friend</button>
            </div>
          </div>
          <textarea
            placeholder="What's on your mind?"
            className={add.textArea}
            spellCheck="false"
          ></textarea>
          <div className={add.emojiWrapper}>
            <button className={add.emoji}>
              <img
                src="https://winka-social-network.netlify.app/static/media/smile.802e4e1c.png"
                alt=""
              />
            </button>
          </div>
          <div className={add.postButton}>
            <span>Add to your post</span>
            <div className={add.buttons}>
              <button>
                <img
                  src="data:image/png;base64,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"
                  alt=""
                />
              </button>
              <button>
                <img
                  src="data:image/png;base64,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"
                  alt=""
                />
              </button>
              <button>
                <img
                  src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABmJLR0QA/wD/AP+gvaeTAAAC90lEQVRoge1YPUxTURT+zmvRVyyjQQeNEjcmUgdJZDBuJuhAbEAZGZDVRBlxw7g7aKILJMayIKMxmpCqkwxodDEYiH+hMMBr2sp97zhUiIq99517KYXYb+z3nfPOud/3flKgiSb+b5BrA57pbUUCoyBcAXAMwBIIk1jzxymbK0l1u7oAz/S2IolnAM78g36Fdf88ZXOluDqbGTyboi0kMFpjKADoRlvlpkhnAbcFqnHQgK+KdBZwW6Ca5Th8XJ0YrgssaVnGolAnhmuEJg2KCZHOAm4LrPnjAL+sweYR+HdEOgu4vwceX06hrXQDoEEAxwEsAjwBP7hN516UTbpb7aP33wSZYSIMAdhgoqEnZ/2nu7aALS48D460JJLXQTwMIP0b9XG6J3Uqbp+kyxBjzN5cvtzPzAMEygA4KuvA234hIJJ0sF6gb7bcMZevTIHRRTtkJAPLxLgmqbG6ct9suWMD/JqAwzb1f0MpYHWVi0Ep6p4fTM9LasVPoTFmTxGmdmL4SoXx+UuE9x8Uvn0PDwVr/BBjLJpJHKG5fLkfjK64+ihivH0XxpVnTrQH2U/Ao7gFNu8Bw3fNn1BKllJiDEj08gUYGYk8jH34WzgtEds4IMq+UtsflQa0S8Q2CyQkYgsHRP1dv0aNUKHYARHqvkCo6tt/Fxyob//6O7DfI6T2e4T2oAN0EcDXuGqhA8sAspIC8QLTPf6MQqWTgXtx9FFED2K2ziUUOhdG2nKSeZw+5C/NlooAWjWS4nRPKn3y7rpBR8WFkXS6Nl8brvfAioEvxNOxqU9NOP6tQgUtDdocTK8jPa+D0wLErL0wb/KsH5ANvA5OC7ApGr9OlkivYwOvQ10dAFWzbTphapQDINKfLFd5MjjVMAci801cAAD29qoDUWSIUJVnw1OoYTcxPE9vPVd5MkTNM/DaWttCAEAY6qPhqQIARKyPWtQoBzYzXrP5D68AAMlIr0uGXmMWONCS0l44cTC1AgCVil5XVinrCDXRxP+On4vYLW+UzoE9AAAAAElFTkSuQmCC"
                  alt=""
                />
              </button>
              <button>
                <img
                  src="https://winka-social-network.netlify.app/static/media/location.64cdcb0e.png"
                  alt=""
                />
              </button>
            </div>
          </div>
        </div>

        <div className={add.footer}>
          <button className={add.button}>Close</button>
        </div>
      </div>
    </div>
  );
};

export default PostModal;

import Lottie from "react-lottie";
import { useLoadingStore } from "~/lib/stores/useLoadingStore";
import loadingAnimation from "@/assets/lotties/loading.json";

export const GlobalLoading = () => {
  const isLoading = useLoadingStore((state) => state.isLoading);

  if (!isLoading) return null;

  return (
    <div className="fixed inset-0 z-[9999] flex items-center justify-center bg-black/40">
      <Lottie
        options={{
          animationData: loadingAnimation,
          autoplay: true,
          loop: true,
        }}
        width={400}
        height={400}
      />
    </div>
  );
};
